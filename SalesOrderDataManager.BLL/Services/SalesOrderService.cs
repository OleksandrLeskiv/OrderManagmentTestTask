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

    public async Task<SalesOrderDTO> AddOrUpdate(SalesOrderDTO salesOrderDto)
    {
        var existingOrder = await _unitOfWork.SalesOrders
            .FindFirstByCondition(a => a.Id == salesOrderDto.Id, true);
        if (existingOrder is null)
        {
            var salesOrder = _mapper.Map<SalesOrder>(salesOrderDto);
            var entity =  await _unitOfWork.SalesOrders.Add(salesOrder);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SalesOrderDTO>(entity);
        }

        existingOrder.Name = salesOrderDto.Name;
        existingOrder.State = salesOrderDto.State;

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SalesOrderDTO>(existingOrder);
    }

    public async Task<IReadOnlyList<SalesOrderDTO>> GetAllByCondition(Expression<Func<SalesOrder, bool>> func)
    {
        var entites = await _unitOfWork.SalesOrders.FindAllByCondition(func);
        return _mapper.Map<List<SalesOrderDTO>>(entites).AsReadOnly();
    }

    public async Task<SalesOrderDTO?> GetFirstByCondition(Expression<Func<SalesOrder, bool>> func)
    {
        var entity = await _unitOfWork.SalesOrders.FindFirstByCondition(func);
        return _mapper.Map<SalesOrderDTO>(entity);
    }

    public async Task DeleteById(Guid id)
    {
        await _unitOfWork.SalesOrders.DeleteById(id);
        await _unitOfWork.SaveChangesAsync();
    }
}