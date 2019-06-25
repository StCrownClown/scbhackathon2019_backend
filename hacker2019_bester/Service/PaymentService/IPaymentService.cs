using hacker2019_bester.Models;

namespace hacker2019_bester.Service
{
    public interface IPaymentService
    {
        PaymentResponse DeeplinkTransactions(string customerId, CustomerResponse customer, PaymentRequest request, Header header);
    }
}
