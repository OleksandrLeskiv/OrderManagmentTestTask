using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class WindowRepository : IWindowRepository
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

    public async Task DeleteById(Guid id)
    {
        foreach (var window in _applicationDbContext.Windows.Where(a => a.Id == id))
        {
            var elements = _applicationDbContext.SubElements
                .Where(a => a.WindowId == window.Id);

            _applicationDbContext.SubElements.RemoveRange(elements);

            _applicationDbContext.Windows.Remove(window);
        }
    }

    public Task<Window?> FindFirstByCondition(Expression<Func<Window, bool>> func, bool trackChanges = false)
        => trackChanges
            ? _applicationDbContext
                .Windows.FirstOrDefaultAsync(func)
            : _applicationDbContext
                .Windows
                .AsNoTracking()
                .FirstOrDefaultAsync(func);

    public async Task<Window> Add(Window window)
    {
        var added = await _applicationDbContext.Windows.AddAsync(window);
        return added.Entity;
    }
}