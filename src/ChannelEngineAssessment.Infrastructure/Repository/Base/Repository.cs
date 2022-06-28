using ChannelEngineAssessment.Core.Entities;
using ChannelEngineAssessment.Core.Entities.Base;
using ChannelEngineAssessment.Core.Repositories.Base;
using ChannelEngineAssessment.Core.Specifications.Base;
using ChannelEngineAssessment.Infrastructure.Data;
using ChannelEngineAssessment.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Infrastructure.Repository.Base
{
    public class Repository<T> 
    {
        #region Url Info
        private const string GetOrderURL = "https://api-dev.channelengine.net/api/v2/orders?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        private const string UpdateProductURL = "https://api-dev.channelengine.net/api/v2/offer/stock?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        #endregion

        public async Task<IReadOnlyList<T>> GetAllAsync(string status)
        {
            try
            {
                var httpClient = new HttpClient();
                var content = await httpClient.GetStringAsync(GetOrderURL + "&statuses=" + status);
                var orders = await Task.Run(() => JsonConvert.DeserializeObject<OrderResponse>(content));
                return (IReadOnlyList<T>)orders.Content;
            }
            catch (Exception ex)
            {

                throw new InfrastructureException("GetAllAsync exception", ex);
            }
           
        }

        public async Task<bool> UpdateStockAsync(int stock, int StockLocationId, string merchProductNo)
        {
            var result = false;
            try
            {
                var stockInfo = new List<StockUpdate>();
                stockInfo.Add(new StockUpdate
                {
                    MerchantProductNo = merchProductNo,
                    StockLocations = new List<StockInfo> { new StockInfo { Stock = stock, StockLocationId = StockLocationId } }
                });
                string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(stockInfo);
                HttpWebRequest request = WebRequest.CreateHttp(UpdateProductURL);
                request.Method = "PUT";
                request.AllowWriteStreamBuffering = false;
                request.ContentType = "application/json";
                request.Accept = "Accept=application/json";
                request.SendChunked = false;
                request.ContentLength = serializedObject.Length;
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(serializedObject);
                }
                var response = await request.GetResponseAsync() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw new InfrastructureException("GetAllAsync exception", ex);
            }

            return result;
        }


    }
}
