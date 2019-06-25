using Microsoft.AspNetCore.Mvc;
using hacker2019_bester.Service;
using hacker2019_bester.Models;

namespace hacker2019_bester.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ICustomerService customerService;

        public UserController(IAuthenticationService authenticationService, ICustomerService customerService)
        {
            this.authenticationService = authenticationService;
            this.customerService = customerService;
        }

        [HttpGet("api/users")]
        public CustomerResponse GetCustomer()
        {
            string customerId = Request.Headers["resourceOwnerId"];

            Header header = new Header();

            authenticationService.GetOauthAuthorize(header);

            AuthenticationResponse accessToken = authenticationService.OAuthToken(header);

            header.authorization = accessToken.data.tokenType + " " + accessToken.data.accessToken;

            CustomerResponse getUser = customerService.CustomersProfile(customerId, header);

            return getUser;
        }
    }
}
