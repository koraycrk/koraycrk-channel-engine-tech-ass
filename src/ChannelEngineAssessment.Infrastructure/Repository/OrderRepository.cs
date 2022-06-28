
using ChannelEngineAssessment.Core.Entities;
using ChannelEngineAssessment.Core.Repositories;
using ChannelEngineAssessment.Core.Specifications;
using ChannelEngineAssessment.Infrastructure.Data;
using ChannelEngineAssessment.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        

        public async Task<IEnumerable<Order>> GetorderByStatusAsync(string status)
        {
            var spec = new OrderWithStatusSpecification(status);
            return await GetAllAsync(status);

            // second way
            // return await GetAsync(x => x.ProductName.ToLower().Contains(productName.ToLower()));

            // third way
            //return await _dbContext.Products
            //    .Where(x => x.ProductName.Contains(productName))
            //    .ToListAsync();
        }

        public async Task<bool> UpdateProductStockAsync(int stock, int StockLocationId, string merchProductNo)
        {
            
            return await UpdateStockAsync(stock, StockLocationId, merchProductNo);

            // second way
            // return await GetAsync(x => x.ProductName.ToLower().Contains(productName.ToLower()));

            // third way
            //return await _dbContext.Products
            //    .Where(x => x.ProductName.Contains(productName))
            //    .ToListAsync();
        }
    }
}
