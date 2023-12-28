using System.Linq.Expressions;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Interfaces;

public interface ISalesOrderService
{
    Task Add(SalesOrderDTO salesOrderDto);
    Task<IReadOnlyList<SalesOrderDTO>> GetAllByCondition(Expression<Func<SalesOrder, bool>> func);
}