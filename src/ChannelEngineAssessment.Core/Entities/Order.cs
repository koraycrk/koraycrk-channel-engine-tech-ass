using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineAssessment.Core.Entities
{
    public class BillingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }

    }
    public class ShippingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }

    }
    public class StockLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Lines
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public double OriginalFeeFixed { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public string JurisCode { get; set; }
        public string JurisName { get; set; }
        public double VatRate { get; set; }
        
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public double Quantity { get; set; }
        public double CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public double FeeFixed { get; set; }
        public double FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

    }
    public class ExtraData
    {
        public string Data { get; set; }

}
public class Order
{
    public int Id { get; set; }
    public string ChannelName { get; set; }
    public int ChannelId { get; set; }
    public string GlobalChannelName { get; set; }
    public int GlobalChannelId { get; set; }
    public string ChannelOrderSupport { get; set; }
    public string ChannelOrderNo { get; set; }
    public string MerchantOrderNo { get; set; }
    public string Status { get; set; }
    public bool IsBusinessOrder { get; set; }
    public DateTime AcknowledgedDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string MerchantComment { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
    public double SubTotalInclVat { get; set; }
    public double SubTotalVat { get; set; }
    public double ShippingCostsVat { get; set; }
    public double TotalInclVat { get; set; }
    public double TotalVat { get; set; }
    public double OriginalSubTotalInclVat { get; set; }
    public double OriginalSubTotalVat { get; set; }
    public double OriginalShippingCostsInclVat { get; set; }
    public double OriginalShippingCostsVat { get; set; }
    public double OriginalTotalInclVat { get; set; }
    public double OriginalTotalVat { get; set; }
    public IList<Lines> Lines { get; set; }
    public double ShippingCostsInclVat { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IList<object> CompanyRegistrationNo { get; set; }
    public IList<object> VatNo { get; set; }
    public string PaymentMethod { get; set; }
    public IList<object> PaymentReferenceNo { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime OrderDate { get; set; }
    public IList<object> ChannelCustomerNo { get; set; }
    

}

    public class OrderResponse
    {
        public IEnumerable<Order> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public string ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public string RequestId { get; set; }
        public string LogId { get; set; }
        public bool Success { get; set; }
        public string  Message { get; set; }
    }
}
