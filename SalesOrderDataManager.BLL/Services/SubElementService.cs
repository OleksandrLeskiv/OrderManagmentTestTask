using System.Linq.Expressions;
using AutoMapper;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.BLL.Interfaces;
using SalesOrderDataManager.DAL.Entities;
using SalesOrderDataManager.DAL.Interfaces;

namespace SalesOrderDataManager.BLL.Services;

public class SubElementService : ISubElementService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubElementService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<SubElementDTO>> GetAllByCondition(Expression<Func<SubElement, bool>> func)
    {
        var all = await _unitOfWork.SubElements.FindAllByCondition(func);
        return _mapper.Map<List<SubElementDTO>>(all).AsReadOnly();
    }

    public async Task DeleteById(Guid id)
    {
        await _unitOfWork.SubElements.DeleteById(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<SubElementDTO?> AddOrUpdate(SubElementDTO subElement)
    {
        var existingSubElement = await _unitOfWork.SubElements
            .FindFirstByCondition(a => a.Id == subElement.Id, true);
        if (existingSubElement is null)
        {
            var salesOrder = _mapper.Map<SubElement>(subElement);
            var entity = await _unitOfWork.SubElements.Add(salesOrder);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SubElementDTO>(entity);
        }

        existingSubElement.Element = subElement.Element;
        existingSubElement.Type = subElement.Type;
        existingSubElement.Width = subElement.Width;
        existingSubElement.Height = subElement.Height;

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SubElementDTO>(existingSubElement);
    }
}