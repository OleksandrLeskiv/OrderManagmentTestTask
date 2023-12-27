using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Lazy<ISalesOrderRepository> _salesOrders;
    private readonly Lazy<ISubElementRepository> _subElements;
    private readonly Lazy<IWindowRepository> _windows;

    public UnitOfWork(ApplicationDbContext context, Lazy<ISalesOrderRepository> salesOrders, Lazy<ISubElementRepository> subElements,
        Lazy<IWindowRepository> windows)
    {
        _context = context;
        _salesOrders = salesOrders;
        _subElements = subElements;
        _windows = windows;
    }

    public ISalesOrderRepository SalesOrders => _salesOrders.Value;
    public ISubElementRepository SubElements => _subElements.Value;
    public IWindowRepository Windows => _windows.Value;
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}