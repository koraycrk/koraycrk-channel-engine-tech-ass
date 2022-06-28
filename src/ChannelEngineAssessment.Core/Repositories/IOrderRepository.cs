using ChannelEngineAssessment.Core.Entities;
using ChannelEngineAssessment.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetorderByStatusAsync(string status);
        Task<bool> UpdateProductStockAsync(int stock, int StockLocationId, string merchProductNo);
    }
}
