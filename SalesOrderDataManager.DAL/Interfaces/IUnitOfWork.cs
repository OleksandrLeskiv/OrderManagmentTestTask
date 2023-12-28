namespace SalesOrderDataManager.DAL.Interfaces;

public interface IUnitOfWork
{
    ISalesOrderRepository SalesOrders { get; }
    ISubElementRepository SubElements { get; }
    IWindowRepository Windows { get; }
    Task SaveChangesAsync();
}