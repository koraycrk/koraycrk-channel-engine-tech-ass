using AutoMapper;
using ChannelEngineAssessment.Application.Models;
using ChannelEngineAssessment.Web.ViewModels;

namespace ChannelEngineAssessment.Web.Mapper
{
    public class AspnetRunProfile : Profile
    {
        public AspnetRunProfile()
        {
            CreateMap<ProductModel, ProductViewModel>().ReverseMap();
            CreateMap<StockLocationModel, StockLocationViewModel>().ReverseMap();
        }
    }
}
