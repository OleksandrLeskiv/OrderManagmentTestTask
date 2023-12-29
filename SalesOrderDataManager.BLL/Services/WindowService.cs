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

    public async Task DeleteById(Guid id)
    {
        await _unitOfWork.Windows.DeleteById(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<WindowDTO?> AddOrUpdate(WindowDTO window)
    {
        var existingObj = await _unitOfWork.Windows
            .FindFirstByCondition(a => a.Id == window.Id, true);

        if (existingObj is null)
        {
            var windowDto = _mapper.Map<Window>(window);
            var entity = await _unitOfWork.Windows.Add(windowDto);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<WindowDTO>(entity);
        }

        existingObj.Name = window.Name;
        existingObj.QuantityOfWindows = window.QuantityOfWindows;
        existingObj.TotalSubElements = window.TotalSubElements;
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<WindowDTO>(existingObj);
    }
}