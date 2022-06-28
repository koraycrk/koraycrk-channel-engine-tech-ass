using AspnetRun.Application.Models;
using ChannelEngineAssessment.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderService
    {        
        Task<IEnumerable<ProductModel>> GetProductByStatus(string status);
        Task<bool> UpdateStockOfProduct(int stock, int StockLocationId, string merchProductNo);

        List<ProductModel> GetTop5Product(List<ProductModel> products);
    }
}
