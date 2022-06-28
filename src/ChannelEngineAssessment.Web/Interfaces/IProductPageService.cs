using ChannelEngineAssessment.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Web.Interfaces
{
    public interface IProductPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts(string status);
        Task<bool> UpdateProdctStock(int stock, int StockLocationId, string merchProductNo);
    }
}
