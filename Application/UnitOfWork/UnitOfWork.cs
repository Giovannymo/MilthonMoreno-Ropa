using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SkelettonContext _context;
    private IRol _roles;
    private IUser _users;
    private IUserRol _userRoles;
    private IClothing _clothings;
    private IColor _colors;
    private ICompany _companies;
    private ICountry _countries;
    private ICustomer _customers;
    private IDetailOrder _detailOrders;
    private IDetailSell _detailSells;
    private IEmployee _employees;
    private IGenre _genres;
    private IInput _inputs;
    private IInputClothing _inputClothings;
    private IInputSupplier _inputSuppliers;
    private IInventory _inventories;
    private IInventorySize _inventorySizes;
    private IJobTitle _jobTitles;
    private IMethodPayment _methodPayments;
    private IMunicipality _municipalities;
    private IOrder _orders;
    private ISell _sells;
    private ISize _sizes;
    private IState _states;
    private IStatus _status;
    private ISupplier _suppliers;
    private ITypePerson _typePersons;
    private ITypeProtection _typeProtections;
    private ITypeStatus _typeStatus;

    public UnitOfWork(SkelettonContext context)
    {
        _context = context;
    }
    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }
    public IUserRol UserRoles
    {
        get
        {
            if (_userRoles == null)
            {
                _userRoles = new UserRolRepository(_context);
            }
            return _userRoles;
        }
    }

    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public IClothing Clothings
    {
        get
        {
            if (_clothings == null)
            {
                _clothings = new ClothingRepository(_context);
            }
            return _clothings;
        }
    }
    public IColor Colors
    {
        get
        {
            if (_colors == null)
            {
                _colors = new ColorRepository(_context);
            }
            return _colors;
        }
    }
    public ICompany Companies
    {
        get
        {
            if (_companies == null)
            {
                _companies = new CompanyRepository(_context);
            }
            return _companies;
        }
    }
    public ICustomer Customers
    {
        get
        {
            if (_customers == null)
            {
                _customers = new CustomerRepository(_context);
            }
            return _customers;
        }
    }
    public IDetailOrder DetailOrders
    {
        get
        {
            if (_detailOrders == null)
            {
                _detailOrders = new DetailOrderRepository(_context);
            }
            return _detailOrders;
        }
    }
    public IDetailSell DetailSells
    {
        get
        {
            if (_detailSells == null)
            {
                _detailSells = new DetailSellRepository(_context);
            }
            return _detailSells;
        }
    }
    public IEmployee Employees
    {
        get
        {
            if (_employees == null)
            {
                _employees = new EmployeeRepository(_context);
            }
            return _employees;
        }
    }
    public IGenre Genres
    {
        get
        {
            if (_genres == null)
            {
                _genres = new GenreRepository(_context);
            }
            return _genres;
        }
    }
    public IInputClothing InputClothings
    {
        get
        {
            if (_inputClothings == null)
            {
                _inputClothings = new InputClothingRepository(_context);
            }
            return _inputClothings;
        }
    }
    public IInput Inputs
    {
        get
        {
            if (_inputs == null)
            {
                _inputs = new InputRepository(_context);
            }
            return _inputs;
        }
    }
    public IInputSupplier InputSuppliers
    {
        get
        {
            if (_inputSuppliers == null)
            {
                _inputSuppliers = new InputSupplierRepository(_context);
            }
            return _inputSuppliers;
        }
    }
    public IInventory Inventories
    {
        get
        {
            if (_inventories == null)
            {
                _inventories = new InventoryRepository(_context);
            }
            return _inventories;
        }
    }
    public IInventorySize InventorySizes
    {
        get
        {
            if (_inventorySizes == null)
            {
                _inventorySizes = new InventorySizeRepository(_context);
            }
            return _inventorySizes;
        }
    }
    public IJobTitle JobTitles
    {
        get
        {
            if (_jobTitles == null)
            {
                _jobTitles = new JobTitleRepository(_context);
            }
            return _jobTitles;
        }
    }
    public IMethodPayment MethodPayments
    {
        get
        {
            if (_methodPayments == null)
            {
                _methodPayments = new MethodPaymentRepository(_context);
            }
            return _methodPayments;
        }
    }
    public IMunicipality Municipalities
    {
        get
        {
            if (_municipalities == null)
            {
                _municipalities = new MunicipalityRepository(_context);
            }
            return _municipalities;
        }
    }
    public IOrder Orders
    {
        get
        {
            if (_orders == null)
            {
                _orders = new OrderRepository(_context);
            }
            return _orders;
        }
    }
    public ISell Sells
    {
        get
        {
            if (_sells == null)
            {
                _sells = new SellRepository(_context);
            }
            return _sells;
        }
    }
    public ISize Sizes
    {
        get
        {
            if (_sizes == null)
            {
                _sizes = new SizeRepository(_context);
            }
            return _sizes;
        }
    }
    public IState States
    {
        get
        {
            if (_states == null)
            {
                _states = new StateRepository(_context);
            }
            return _states;
        }
    }
    public IStatus Status
    {
        get
        {
            if (_status == null)
            {
                _status = new StatusRepository(_context);
            }
            return _status;
        }
    }
    public ISupplier Suppliers
    {
        get
        {
            if (_suppliers == null)
            {
                _suppliers = new SupplierRepository(_context);
            }
            return _suppliers;
        }
    }
    public ITypePerson TypePersons
    {
        get
        {
            if (_typePersons == null)
            {
                _typePersons = new TypePersonRepository(_context);
            }
            return _typePersons;
        }
    }
    public ITypeProtection TypeProtections
    {
        get
        {
            if (_typeProtections == null)
            {
                _typeProtections = new TypeProtectionRepository(_context);
            }
            return _typeProtections;
        }
    }
    public ITypeStatus TypeStatus
    {
        get
        {
            if (_typeStatus == null)
            {
                _typeStatus = new TypeStatusRepository(_context);
            }
            return _typeStatus;
        }
    }
    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository(_context);
            }
            return _countries;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}