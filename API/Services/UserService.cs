using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<User> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<string> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User
        {
            Email = registerDto.Email,
            UserName = registerDto.UserName,
            IdenNumber = registerDto.IdenNumber,
        };
        user.Password = _passwordHasher.HashPassword(user, registerDto.Password); //Encrypt password
        var existingUser = _unitOfWork.Users
                                    .Find(u => u.UserName.ToLower() == registerDto.UserName.ToLower() || u.IdenNumber == registerDto.IdenNumber)
                                    .FirstOrDefault();
        if (existingUser == null)
        {
            var rolDefault = _unitOfWork.Roles
                                    .Find(u => u.Name == Authorization.rol_default.ToString())
                                    .First();
            try
            {
                user.Roles.Add(rolDefault);
                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveAsync();

                return $"User {registerDto.UserName} has been registered successfully";
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return $"Error: {message}";
            }
        }
        else
        {
            return $"User {registerDto.UserName} already registered, change the identification or username.";
        }
    }

    public async Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
        DataUserDto dataUserDto = new DataUserDto();
        var user = await _unitOfWork.Users
                    .GetByUserNameAsync(model.UserName);

        if (user == null)
        {
            dataUserDto.IsAuthenticated = false;
            dataUserDto.Message = $"User does not exist with UserName {model.UserName}.";
            return dataUserDto;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);

        if (result == PasswordVerificationResult.Success)
        {
            dataUserDto.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            dataUserDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            dataUserDto.Email = user.Email;
            dataUserDto.UserName = user.UserName;
            dataUserDto.Roles = user.Roles
                                            .Select(u => u.Name)
                                            .ToList();

            if (user.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                dataUserDto.RefreshToken = activeRefreshToken.Token;
                dataUserDto.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = CreateRefreshToken();
                dataUserDto.RefreshToken = refreshToken.Token;
                dataUserDto.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();
            }

            return dataUserDto;
        }
        dataUserDto.IsAuthenticated = false;
        dataUserDto.Message = $"Credenciales incorrectas para el usuario {user.UserName}.";
        return dataUserDto;
    }

    public async Task<string> AddRoleAsync(AddRoleDto model)
    {
        var usuario = await _unitOfWork.Users
                            .GetByUserNameAsync(model.UserName);

        if (usuario == null)
        {
            return $"No existe algun usuario registrado con la cuenta olvido algun caracter?{model.UserName}.";
        }

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

        if (result == PasswordVerificationResult.Success)
        {
            var rolExists = _unitOfWork.Roles
                                            .Find(u => u.Name.ToLower() == model.Role.ToLower())
                                            .FirstOrDefault();

            if (rolExists != null)
            {
                var userHasRole = usuario.Roles
                                            .Any(u => u.Id == rolExists.Id);

                if (userHasRole == false)
                {
                    usuario.Roles.Add(rolExists);
                    _unitOfWork.Users.Update(usuario);
                    await _unitOfWork.SaveAsync();
                }

                return $"Rol {model.Role} agregado a la cuenta {model.UserName} de forma exitosa.";
            }

            return $"Rol {model.Role} no encontrado.";
        }

        return $"Credenciales incorrectas para el ususario {usuario.UserName}.";
    }

    public async Task<DataUserDto> RefreshTokenAsync(string refreshToken)
    {
        var dataUserDto = new DataUserDto();

        var usuario = await _unitOfWork.Users
                        .GetByRefreshTokenAsync(refreshToken);

        if (usuario == null)
        {
            dataUserDto.IsAuthenticated = false;
            dataUserDto.Message = $"Token is not assigned to any user.";
            return dataUserDto;
        }

        var refreshTokenBd = usuario.RefreshTokens.Single(x => x.Token == refreshToken);

        if (!refreshTokenBd.IsActive)
        {
            dataUserDto.IsAuthenticated = false;
            dataUserDto.Message = $"Token is not active.";
            return dataUserDto;
        }
        //Revoque the current refresh token and
        refreshTokenBd.Revoked = DateTime.UtcNow;
        //generate a new refresh token and save it in the database
        var newRefreshToken = CreateRefreshToken();
        usuario.RefreshTokens.Add(newRefreshToken);
        _unitOfWork.Users.Update(usuario);
        await _unitOfWork.SaveAsync();
        //Generate a new Json Web Token
        dataUserDto.IsAuthenticated = true;
        JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
        dataUserDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        dataUserDto.Email = usuario.Email;
        dataUserDto.UserName = usuario.UserName;
        dataUserDto.Roles = usuario.Roles
                                        .Select(u => u.Name)
                                        .ToList();
        dataUserDto.RefreshToken = newRefreshToken.Token;
        dataUserDto.RefreshTokenExpiration = newRefreshToken.Expires;
        return dataUserDto;
    }

    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = RandomNumberGenerator.Create())
        {
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                Expires = DateTime.UtcNow.AddMinutes(3),
                Created = DateTime.UtcNow
            };
        }
    }

    private JwtSecurityToken CreateJwtToken(User usuario)
    {
        var roles = usuario.Roles;
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim("roles", role.Name));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim("uid", usuario.Id.ToString())
        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }
}