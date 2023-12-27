using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SubElement> SubElements => Set<SubElement>();
    public DbSet<Window> Windows => Set<Window>();
}