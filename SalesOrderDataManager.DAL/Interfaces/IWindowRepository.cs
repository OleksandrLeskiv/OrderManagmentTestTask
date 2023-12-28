using System.Linq.Expressions;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Interfaces;

public interface IWindowRepository
{
    Task<List<Window>> FindAllByCondition(Expression<Func<Window, bool>> func);
    public Task SaveAsync();
}