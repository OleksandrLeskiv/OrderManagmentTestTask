using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class WindowRepository :  IWindowRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public WindowRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<List<Window>> FindAllByCondition(Expression<Func<Window, bool>> func)
        => _applicationDbContext
            .Windows
            .AsNoTracking()
            .Where(func)
            .ToListAsync();

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}