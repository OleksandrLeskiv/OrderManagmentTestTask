using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class SubElementRepository : RepositoryBase<SubElement>, ISubElementRepository
{
    public SubElementRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }
}