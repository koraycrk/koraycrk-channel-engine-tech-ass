using AspnetRun.Application.Interfaces;
using ChannelEngineAssessment.Application.Models;
using ChannelEngineAssessment.Web.Interfaces;
using ChannelEngineAssessment.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Web.Services
{
    public class ProductPageService : IProductPageService
    {
        private readonly IOrderService _orderAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductPageService> _logger;

        public ProductPageService(IOrderService orderAppService, IMapper mapper, ILogger<ProductPageService> logger)
        {
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts(string status)
        {
            if (!string.IsNullOrWhiteSpace(status))
            {
                var list = await _orderAppService.GetProductByStatus(status);
                var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
                return mapped;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateProdctStock(int stock, int StockLocationId, string merchProductNo)
        {
            var result = await _orderAppService.UpdateStockOfProduct(stock, StockLocationId, merchProductNo);
            return result;
        }


    }
}
