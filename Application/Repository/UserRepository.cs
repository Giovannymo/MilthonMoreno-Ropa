using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class UserRepository : GenericRepository<User>, IUser
{
    private readonly SkelettonContext _context;

    public UserRepository(SkelettonContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<User> GetByUserNameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
    }
    
    public async Task<IEnumerable<User>> GetAllRolesAsync()
    {
        var users = await _context.Users
            .Select(u => new User
            {
                Id = u.Id,
                UserName = u.UserName,
                Roles = u.Roles.FirstOrDefault() != null ? new List<Rol> { u.Roles.First() } : new List<Rol>()
            })
            .ToListAsync();
        return users;
    }
}