using System.Linq.Expressions;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Interfaces;

public interface ISubElementService
{
    Task<IReadOnlyList<SubElementDTO>> GetAllByCondition(Expression<Func<SubElement, bool>> func);
    Task DeleteById(Guid id);
    Task<SubElementDTO?> AddOrUpdate(SubElementDTO subElement);
}