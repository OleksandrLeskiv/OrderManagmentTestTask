using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class SalesOrderRepository : RepositoryBase<SalesOrder>, ISalesOrderRepository
{
    public SalesOrderRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }
}