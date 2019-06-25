using hacker2019_bester.Models;
using hacker2019_bester.Service;
using Microsoft.AspNetCore.Mvc;

namespace hacker2019_bester.Controllers
{
    public class LoanController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILoanCalculatorService loanCalculatorService;

        public LoanController(IAuthenticationService authenticationService, ILoanCalculatorService loanCalculatorService)
        {
            this.authenticationService = authenticationService;
            this.loanCalculatorService = loanCalculatorService;
        }

        [HttpPost("api/loans/simulator")]
        public LoanSimulatorResponse LoanSimulator([FromBody] LoanSimulatorRequest request)
        {
            string customerId = Request.Headers["resourceOwnerId"];

            Header header = new Header();

            authenticationService.GetOauthAuthorize(header);

            AuthenticationResponse accessToken = authenticationService.OAuthToken(header);

            header.authorization = accessToken.data.tokenType + " " + accessToken.data.accessToken;

            LoanSimulatorResponse response = loanCalculatorService.LoanSimulator(customerId, request, header);

            return response;
        }
    }
}
