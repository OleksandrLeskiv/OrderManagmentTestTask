using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly ApplicationDbContext ApplicationDbContext;

    public RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        ApplicationDbContext = applicationDbContext;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        => !trackChanges
                ? ApplicationDbContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking()
                : ApplicationDbContext.Set<T>()
                    .Where(expression);

    public void Create(T entity) => ApplicationDbContext.Set<T>().Add(entity);
    public void Update(T entity) => ApplicationDbContext.Set<T>().Update(entity);
    public void Delete(T entity) => ApplicationDbContext.Set<T>().Remove(entity);
}