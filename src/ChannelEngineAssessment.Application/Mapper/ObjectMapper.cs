using ChannelEngineAssessment.Application.Models;
using ChannelEngineAssessment.Core.Entities;
using AutoMapper;
using System;
using AspnetRun.Application.Models;

namespace ChannelEngineAssessment.Application.Mapper
{
    // The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ChannelEngineAssessmentDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class ChannelEngineAssessmentDtoMapper : Profile
    {
        public ChannelEngineAssessmentDtoMapper()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<BillingAddress, BillingAddressModel>().ReverseMap();
            CreateMap<ShippingAddress, ShippingAddressModel>().ReverseMap();
            CreateMap<Lines, LineModel>()
                 .ForPath(dest => dest.StockLocation, opt => opt.MapFrom(src => src.StockLocation))
                .ReverseMap();
            CreateMap<StockLocation, StockLocationModel>().ReverseMap();
            CreateMap<ProductModel, LineModel>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.TotalQuantity))
                .ForMember(dest => dest.Gtin, opt => opt.MapFrom(src => src.GTIN))
                .ForMember(dest => dest.MerchantProductNo, opt => opt.MapFrom(src => src.MerchantProductNo))
                .ForPath(dest => dest.StockLocation.Id, opt => opt.MapFrom(src => src.StockLocationId))
                .ReverseMap();
        }
    }
}
