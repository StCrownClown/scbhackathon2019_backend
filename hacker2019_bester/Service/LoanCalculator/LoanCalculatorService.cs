using hacker2019_bester.Configurations;
using hacker2019_bester.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace hacker2019_bester.Service
{
    public class LoanCalculatorService : ExternalService, ILoanCalculatorService
    {
        private readonly string APIKey;
        private readonly string APISecret;
        private readonly IAuthenticationService authenticationService;
        
        public LoanCalculatorService(IOptions<SCBApplication> SCBApplication, IAuthenticationService authenticationService) : base(SCBApplication.Value.SCBApiUr)
        {
            APIKey = SCBApplication.Value.APIKey;
            APISecret = SCBApplication.Value.APISecret;
            this.authenticationService = authenticationService;
        }

        public LoanSimulatorResponse LoanSimulator(string customerId, LoanSimulatorRequest request, Header header)
        {
            header.apikey = APIKey;
            header.apisecret = APISecret;
            header.resourceOwnerId = customerId;

            WebClient webC = authenticationService.ConvertHeadertoWebClient(header);

            return Post<LoanSimulatorResponse, LoanSimulatorRequest>("/v1/loanorigination/simulator/calculate", request, webC);
        }
    }
}
