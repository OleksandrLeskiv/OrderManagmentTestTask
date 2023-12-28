using System.Linq.Expressions;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Interfaces;

public interface ISalesOrderRepository
{
    Task<List<SalesOrder>> FindAllByCondition(Expression<Func<SalesOrder, bool>> func);
    Task<SalesOrder?> FindFirstByCondition(Expression<Func<SalesOrder, bool>> func, bool trackChanges = false);
    Task<SalesOrder> Add(SalesOrder emp);
    Task SaveAsync();
    Task DeleteById(Guid id);
}