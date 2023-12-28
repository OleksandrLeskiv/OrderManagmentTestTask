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
            .ToListAsync();

    public Task<SalesOrder?> FindFirstByCondition(Expression<Func<SalesOrder, bool>> func, bool trackChanges = false)
        => trackChanges
            ? _applicationDbContext
                .SalesOrders
                .FirstOrDefaultAsync(func)
            : _applicationDbContext
                .SalesOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(func);

    public async Task<SalesOrder> Add(SalesOrder emp)
    {
        var addedEntity = await _applicationDbContext.SalesOrders.AddAsync(emp);
        return addedEntity.Entity;
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        foreach (var order in _applicationDbContext.SalesOrders.Where(a => a.Id == id))
        {
            foreach (var window in _applicationDbContext.Windows.Where(a => a.OrderId == order.Id))
            {
                var elements = _applicationDbContext.SubElements
                    .Where(a => a.WindowId == window.Id);

                _applicationDbContext.SubElements.RemoveRange(elements);

                _applicationDbContext.Windows.Remove(window);
            }

            _applicationDbContext.SalesOrders.Remove(order);
        }
    }
}