using AutoMapper;
using Store.DataAccess.Entities;
using Store.DTO;

namespace Store.ServiceMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductEf, ProductDto>();
        CreateMap<ProductDto, ProductEf>();
        
        CreateMap<AccountEf, RegisterDto>();
        CreateMap<RegisterDto, AccountEf>();
        
        
    }
}