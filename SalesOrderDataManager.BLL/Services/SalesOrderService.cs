using System.Linq.Expressions;
using AutoMapper;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.BLL.Interfaces;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.BLL.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper  _mapper;
    
    public SalesOrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Add(SalesOrderDTO salesOrderDto)
    {
        var emp = _mapper.Map<SalesOrder>(salesOrderDto);
        await _unitOfWork.SalesOrders.Add(emp);
    }

    public async Task<IReadOnlyList<SalesOrderDTO>> GetAllByCondition(Expression<Func<SalesOrder, bool>> func)
    {
        var entites = await _unitOfWork.SalesOrders.FindAllByCondition(func);
        return _mapper.Map<List<SalesOrderDTO>>(entites).AsReadOnly();
    }
}