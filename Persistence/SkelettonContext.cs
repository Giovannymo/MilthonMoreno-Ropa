using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SkelettonContext : DbContext
{
    public SkelettonContext(DbContextOptions options) : base(options)
    {
        
     }
    public DbSet<Clothing> Clothings { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<DetailOrder> DetailOrders { get; set; }
    public DbSet<DetailSell> DetailSells { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<InputClothing> InputClothings { get; set; }
    public DbSet<Input> Inputs { get; set; }
    public DbSet<InputSupplier> InputSuppliers { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventorySize> InventorySizes { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    public DbSet<MethodPayment> MethodPayments { get; set; }
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Sell> Sells { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}