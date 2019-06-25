namespace hacker2019_bester.Models
{
    public class Payment
    {
        public string transactionId { get; set; }
        public string deeplinkUrl { get; set; }
        public string userRefId { get; set; }
    }

    public class PaymentResponse : BaseResponse
    {
        public Payment data { get; set; }
    }
}
