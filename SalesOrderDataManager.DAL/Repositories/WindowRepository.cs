using SalesOrderDataManager.DAL.Context;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.DAL.Repositories;

public class WindowRepository : RepositoryBase<Window>, IWindowRepository
{
    public WindowRepository(ApplicationDbContext applicationDbContext)
        : base(applicationDbContext)
    {
    }
}