using System.Linq.Expressions;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Interfaces;

public interface IWindowService
{
    Task<IReadOnlyList<WindowDTO>> GetAllByCondition(Expression<Func<Window, bool>> func);
    Task DeleteById(Guid id);
    Task<WindowDTO?> AddOrUpdate(WindowDTO window);
    Task<WindowDTO?> GetFirstByCondition(Expression<Func<Window, bool>> func);
}