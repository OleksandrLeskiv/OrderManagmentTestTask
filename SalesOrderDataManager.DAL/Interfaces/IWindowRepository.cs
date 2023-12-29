using System.Linq.Expressions;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Interfaces;

public interface IWindowRepository
{
    Task<List<Window>> FindAllByCondition(Expression<Func<Window, bool>> func);
    public Task SaveAsync();
    Task DeleteById(Guid id);
    Task<Window?> FindFirstByCondition(Expression<Func<Window, bool>> func, bool trackChanges = false);
    Task<Window> Add(Window windowDto);
}