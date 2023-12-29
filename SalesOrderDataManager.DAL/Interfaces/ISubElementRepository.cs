using System.Linq.Expressions;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.DAL.Interfaces;

public interface ISubElementRepository
{
    public  Task SaveAsync();
    Task<List<SubElement>> FindAllByCondition(Expression<Func<SubElement, bool>> func);
    Task DeleteById(Guid id);
    Task<SubElement?> FindFirstByCondition(Expression<Func<SubElement, bool>> func, bool trackedChanges);
    Task<SubElement> Add(SubElement salesOrder);
}