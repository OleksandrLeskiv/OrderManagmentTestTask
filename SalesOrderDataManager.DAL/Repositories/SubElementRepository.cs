using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class SubElementRepository :  ISubElementRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public SubElementRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }

    public Task<List<SubElement>> FindAllByCondition(Expression<Func<SubElement, bool>> func)
        => _applicationDbContext
            .SubElements
            .AsNoTracking()
            .Where(func)
            .ToListAsync();

    public async Task DeleteById(Guid id)
    {
        var elements = _applicationDbContext.SubElements
            .Where(a => a.Id == id);
        
        _applicationDbContext.SubElements.RemoveRange(elements);
    }

    public Task<SubElement?> FindFirstByCondition(Expression<Func<SubElement, bool>> func, bool trackChanges)
        => trackChanges
            ? _applicationDbContext
                .SubElements
                .FirstOrDefaultAsync(func)
            : _applicationDbContext
                .SubElements
                .AsNoTracking()
                .FirstOrDefaultAsync(func);

    public async Task<SubElement> Add(SubElement subElement)
    {
        var addedEntity = await _applicationDbContext.SubElements.AddAsync(subElement);
        return addedEntity.Entity;
    }
}