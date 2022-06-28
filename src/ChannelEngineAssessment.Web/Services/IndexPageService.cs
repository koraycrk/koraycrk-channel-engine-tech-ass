using AspnetRun.Application.Interfaces;
using AutoMapper;
using ChannelEngineAssessment.Web.Interfaces;
using ChannelEngineAssessment.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Web.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IOrderService _orderAppService;        
        private readonly IMapper _mapper;

        public IndexPageService(IOrderService orderAppService, IMapper mapper)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var list = await _orderAppService.GetProductByStatus("IN_PROGRESS");
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }
    }
}
