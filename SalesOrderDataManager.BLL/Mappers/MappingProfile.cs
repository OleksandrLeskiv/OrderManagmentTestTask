using AutoMapper;
using SalesOrderDataManager.BLL.DTO;
using SalesOrderDataManager.DAL.Entities;

namespace SalesOrderDataManager.BLL.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SalesOrder, SalesOrderDTO>().ReverseMap();
        CreateMap<SubElement, SubElementDTO>().ReverseMap();
        CreateMap<Window, WindowDTO>().ReverseMap();
    }
}