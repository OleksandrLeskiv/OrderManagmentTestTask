using System.Linq.Expressions;
using AutoMapper;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.BLL.Interfaces;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.BLL.Services;

public class WindowService : IWindowService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WindowService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<WindowDTO>> GetAllByCondition(Expression<Func<Window, bool>> func)
    {
        var all = await _unitOfWork.Windows.FindAllByCondition(func);
        return _mapper.Map<List<WindowDTO>>(all).AsReadOnly();
    }
}