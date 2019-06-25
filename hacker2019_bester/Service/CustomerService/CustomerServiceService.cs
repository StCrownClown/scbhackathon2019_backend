using hacker2019_bester.Configurations;
using hacker2019_bester.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace hacker2019_bester.Service
{
    public class CustomerService : ExternalService, ICustomerService
    {
        private readonly string APIKey;
        private readonly string APISecret;
        private readonly IAuthenticationService authenticationService;
        
        public CustomerService(IOptions<SCBApplication> SCBApplication, IAuthenticationService authenticationService) : base(SCBApplication.Value.SCBApiUr)
        {
            APIKey = SCBApplication.Value.APIKey;
            APISecret = SCBApplication.Value.APISecret;
            this.authenticationService = authenticationService;
        }

        public CustomerResponse CustomersProfile(string customerId, Header header)
        {
            header.apikey = APIKey;
            header.apisecret = APISecret;
            header.resourceOwnerId = customerId;

            WebClient webC = authenticationService.ConvertHeadertoWebClient(header);

            return Get<CustomerResponse> ("/v1/customers/profile", webC);
        }
    }
}
