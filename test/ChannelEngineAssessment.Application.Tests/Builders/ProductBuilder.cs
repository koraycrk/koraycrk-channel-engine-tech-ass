using ChannelEngineAssessment.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineAssessment.Application.Tests.Builders
{
    public class ProductBuilder
    {
        public List<ProductModel> GetProducts()
        {
            var list = new List<ProductModel>();
            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo1",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 5
            });

            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo2",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 10
            });

            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo3",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 15
            });

            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo4",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 20
            });

            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo5",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 25
            });

            list.Add(new ProductModel
            {
                GTIN = "GTIN1",
                MerchantProductNo = "MerchantProductNo6",
                Name = "Name1",
                StockLocationId = 1,
                TotalQuantity = 30
            });

            return list;

        }
    }
}
