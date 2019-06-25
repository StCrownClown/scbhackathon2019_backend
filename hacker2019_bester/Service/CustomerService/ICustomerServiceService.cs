using hacker2019_bester.Models;

namespace hacker2019_bester.Service
{
    public interface ICustomerService
    {
        CustomerResponse CustomersProfile(string customerId, Header header);
    }
}
