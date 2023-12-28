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
}