using System.Linq.Expressions;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Interfaces;

public interface IWindowService
{
    Task<IReadOnlyList<WindowDTO>> GetAllByCondition(Expression<Func<Window, bool>> func);
}