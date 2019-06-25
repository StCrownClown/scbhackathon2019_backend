using Newtonsoft.Json;
using System.Collections.Generic;

namespace hacker2019_bester.Models
{
    public class PaymentInfo
    {
        public string type { get; set; }
        public string title { get; set; }
        public string header { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
    }

    public class Analytics
    {
        [JsonProperty(PropertyName = "Product category")]
        public string ProductCategory { get; set; }
        public string Partner { get; set; }
        [JsonProperty(PropertyName = "Product code")]
        public string ProductCode { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Detail3 { get; set; }
        public string Detail4 { get; set; }
        public string Detail5 { get; set; }
        public string Detail6 { get; set; }
    }

    public class MerchantMetaData
    {
        public List<PaymentInfo> paymentInfo { get; set; }
        public Analytics analytics { get; set; }
    }

    public class PaymentRequest
    {
        public int paymentAmount { get; set; }
        public string transactionType { get; set; }
        public string transactionSubType { get; set; }
        public string ref1 { get; set; }
        public string accountTo { get; set; }
        public MerchantMetaData merchantMetaData { get; set; }
    }
}
