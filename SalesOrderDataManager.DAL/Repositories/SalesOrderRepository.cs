using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SalesOrderRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<List<SalesOrder>> FindAllByCondition(Expression<Func<SalesOrder, bool>> func)
        => _applicationDbContext.SalesOrders
            .AsNoTracking()
            .Where(func)
            .Include(a => a.Windows)!
            .ThenInclude(a => a.SubElements)
            .ToListAsync();

    public async Task Add(SalesOrder emp)
    {
        await _applicationDbContext.SalesOrders.AddAsync(emp);
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}