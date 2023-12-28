using System.Linq.Expressions;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Interfaces;

public interface ISalesOrderService
{
    Task<SalesOrderDTO> AddOrUpdate(SalesOrderDTO salesOrderDto);
    Task<IReadOnlyList<SalesOrderDTO>> GetAllByCondition(Expression<Func<SalesOrder, bool>> func);
    Task<SalesOrderDTO?> GetFirstByCondition(Expression<Func<SalesOrder, bool>> func);
    Task DeleteById(Guid id);
}