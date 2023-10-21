namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Users { get; }
    IUserRol UserRoles { get; }
    IClothing Clothings {get;}
     IColor Colors{get;}
     ICompany Companies {get;}
     ICountry Countries {get;}
     ICustomer Customers {get;}
     IDetailOrder DetailOrders {get;}
     IDetailSell DetailSells{get;}
     IEmployee Employees {get;}
     IGenre Genres{get;}
     IInput Inputs{get;}
     IInputClothing InputClothings{get;}
     IInputSupplier InputSuppliers{get;}
     IInventory Inventories {get;}
     IInventorySize InventorySizes{get;}
     IJobTitle JobTitles{get;}
     IMethodPayment MethodPayments {get;}
     IMunicipality Municipalities {get;}
     IOrder Orders{get;}
     ISell Sells {get;}
     ISize Sizes  {get;}
     IState States {get;}
     IStatus Status {get;}
     ISupplier Suppliers {get;}
     ITypePerson TypePersons {get;}
     ITypeProtection TypeProtections {get;}
     ITypeStatus TypeStatus {get;}
    Task<int> SaveAsync();
}