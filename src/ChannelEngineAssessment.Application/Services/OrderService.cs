using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Application.Models;
using AspnetRun.Application.Interfaces;
using ChannelEngineAssessment.Core.Interfaces;
using ChannelEngineAssessment.Application.Mapper;
using System.Linq;
using ChannelEngineAssessment.Application.Models;
using ChannelEngineAssessment.Core.Repositories;

namespace ChannelEngineAssessment.Application.Services
{
    // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAppLogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<IEnumerable<ProductModel>> GetProductByStatus(string status)
        {
            List<ProductModel> products = null;
            var product = await _orderRepository.GetorderByStatusAsync(status);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<LineModel>>(product.SelectMany(o => o.Lines)).ToList();
            if (mapped != null)
            {
                products = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(mapped).ToList();
                products = GetTop5Product(products);

            }
            return products;
        }

        public async Task<bool> UpdateStockOfProduct(int stock, int StockLocationId, string merchProductNo)
        {
            var response = await _orderRepository.UpdateProductStockAsync(stock, StockLocationId, merchProductNo);
            return response;
        }

        public List<ProductModel> GetTop5Product(List<ProductModel> products)
        {

            var query = (from t in products
                         group t by new { t.GTIN, t.Name, t.MerchantProductNo, t.StockLocationId }
                         into grp
                         select new ProductModel
                         {
                             GTIN = grp.Key.GTIN,
                             MerchantProductNo = grp.Key.MerchantProductNo,
                             TotalQuantity = grp.Sum(t => t.TotalQuantity),
                             Name = grp.Key.Name,
                             StockLocationId = grp.Key.StockLocationId
                         }).ToList();

            return query.OrderByDescending(o => o.TotalQuantity).Take(5).ToList();
        }
    }
}
