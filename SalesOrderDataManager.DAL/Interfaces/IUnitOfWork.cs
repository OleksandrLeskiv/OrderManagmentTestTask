namespace SalesOrderDataManager.DAL.Interfaces;

public interface IUnitOfWork
{
    public ISalesOrderRepository SalesOrders { get; }
    public ISubElementRepository SubElements { get; }
    public IWindowRepository Windows { get; }
    public Task SaveAsync();
}