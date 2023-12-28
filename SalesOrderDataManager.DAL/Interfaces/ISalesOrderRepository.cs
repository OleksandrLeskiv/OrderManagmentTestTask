using System.Linq.Expressions;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Interfaces;

public interface ISalesOrderRepository
{
    Task<List<SalesOrder>> FindAllByCondition(Expression<Func<SalesOrder, bool>> func);
    Task Add(SalesOrder emp);
    Task SaveAsync();
}