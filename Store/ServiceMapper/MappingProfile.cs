using AutoMapper;
using AutoMapper.Features;
using Store.DataAccess.ModelsEF;
using Store.DTO;

namespace Store.ServiceMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductEf, ProductDto>();
        CreateMap<ProductDto, ProductEf>();

        CreateMap<OrderEf, OrderInfoDto>();
        CreateMap<OrderInfoDto, OrderEf>();
        
        CreateMap<CartProductEf, CartItem>()
            .ForMember(m => m.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(m => m.Quantity, opt => opt.MapFrom(src => (int)src.Quantity))
            .ForMember(m => m.Name, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "Unknown"))
            .ForMember(m => m.Price, opt => opt.MapFrom(src => src.Product != null ? src.Product.Price : 0))
            .ForMember(m => m.Photo, opt => opt.MapFrom(src => src.Product != null ? src.Product.Photo : Array.Empty<byte>()));

        
        CreateMap<AccountEf, RegisterDto>()
            .ForMember(m=>m.Password, opt=>opt.MapFrom(src=>src.PasswordHash));
        CreateMap<RegisterDto, AccountEf>()
            .ForMember(m=>m.PasswordHash, opt=>opt.MapFrom(src=>src.Password));
        
        CreateMap<LoginDto, AccountEf>()
            .ForMember(m=>m.PasswordHash, opt=>opt.MapFrom(src=>src.Password));
    }
}