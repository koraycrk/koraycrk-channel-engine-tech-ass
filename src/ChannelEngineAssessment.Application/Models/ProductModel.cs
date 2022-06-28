using ChannelEngineAssessment.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public double TotalQuantity { get; set; }
        public string GTIN { get; set; }
        public string MerchantProductNo { get; set; }
        public int StockLocationId { get; set; }
    }
}
