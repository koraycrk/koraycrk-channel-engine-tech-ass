using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Core.Entities
{
    public class StockUpdate
    {
        public string MerchantProductNo { get; set; }
        public List<StockInfo> StockLocations { get; set; }
    }

    public class StockInfo
    {
        public int Stock { get; set; }
        public int StockLocationId { get; set; }
    }
}
