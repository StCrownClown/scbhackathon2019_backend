using hacker2019_bester.Models;
using hacker2019_bester.Service;
using Microsoft.AspNetCore.Mvc;

namespace hacker2019_bester.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IPaymentService paymentService;
        private readonly ICustomerService customerService;

        public PaymentController(IAuthenticationService authenticationService, IPaymentService paymentService, ICustomerService customerService)
        {
            this.authenticationService = authenticationService;
            this.paymentService = paymentService;
            this.customerService = customerService;
        }

        [HttpPost("api/payments")]
        public PaymentResponse Payment([FromBody] PaymentRequest request)
        {
            string customerId = Request.Headers["resourceOwnerId"];

            Header header = new Header();

            authenticationService.GetOauthAuthorize(header);

            AuthenticationResponse accessToken = authenticationService.OAuthToken(header);

            header.authorization = accessToken.data.tokenType + " " + accessToken.data.accessToken;

            CustomerResponse cusomer = customerService.CustomersProfile(customerId, header);

            PaymentResponse response = paymentService.DeeplinkTransactions(customerId, cusomer, request, header);

            return response;
        }
    }
}
