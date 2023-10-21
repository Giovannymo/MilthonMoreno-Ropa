using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserWithRolDto>()
        .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Roles.FirstOrDefault().Name))
        .ReverseMap();

        CreateMap<Clothing, ClothingDto>().ReverseMap();

        CreateMap<Color, ColorDto>().ReverseMap();

        CreateMap<Company, CompanyDto>().ReverseMap();

        CreateMap<Country, CountryDto>().ReverseMap();

        CreateMap<Customer, CustomerDto>().ReverseMap();

        CreateMap<DetailOrder, DetailOrderDto>().ReverseMap();

        CreateMap<DetailSell, DetailSellDto>().ReverseMap();

        CreateMap<Employee, EmployeeDto>().ReverseMap();

        CreateMap<Genre, GenreDto>().ReverseMap();

        CreateMap<Input, InputDto>().ReverseMap();
        CreateMap<InputClothing, InputClothingDto>().ReverseMap();
        CreateMap<InputSupplier, InputSupplierDto>().ReverseMap();
        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<InventorySize, InventorySizeDto>().ReverseMap();
        CreateMap<JobTitle, JobTitleDto>().ReverseMap();
        CreateMap<MethodPayment, MethodPaymentDto>().ReverseMap();
        CreateMap<Municipality, MunicipalityDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<RefreshToken, RefreshTokenCookieDto>().ReverseMap();
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Sell, SellDto>().ReverseMap();
        CreateMap<Size, SizeDto>().ReverseMap();
        CreateMap<State, StateDto>().ReverseMap();
        CreateMap<Status, StatusDto>().ReverseMap();
        CreateMap<Supplier, SupplierDto>().ReverseMap();
        CreateMap<TypePerson, TypePersonDto>().ReverseMap();
        CreateMap<TypeProtection, TypeProtectionDto>().ReverseMap();
        CreateMap<TypeStatus, TypeStatusDto>().ReverseMap();
        CreateMap<User, UserWithRolDto>().ReverseMap();



    }
}