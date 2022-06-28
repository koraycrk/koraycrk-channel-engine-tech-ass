using ChannelEngineAssessment.Core.Entities.Base;
using ChannelEngineAssessment.Core.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Core.Repositories.Base
{
    public interface IRepository<T>
    {
        Task<bool> UpdateStockAsync(int stock, int StockLocationId, string merchProductNo);


    }
}
