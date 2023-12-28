using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Configurations;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
        modelBuilder.ApplyConfiguration(new SubElementConfiguration());
        modelBuilder.ApplyConfiguration(new WindowConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SubElement> SubElements => Set<SubElement>();
    public DbSet<Window> Windows => Set<Window>();
}