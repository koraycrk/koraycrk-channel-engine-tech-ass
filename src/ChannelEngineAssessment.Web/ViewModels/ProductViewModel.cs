using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Web.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string TotalQuantity { get; set; }
        public string GTIN { get; set; }
        public string MerchantProductNo { get; set; }
        public int StockLocationId { get; set; }
    }
}
