using hacker2019_bester.Configurations;
using hacker2019_bester.Models;
using Microsoft.Extensions.Options;
using System.Net;

namespace hacker2019_bester.Service
{
    public class PaymentService : ExternalService, IPaymentService
    {
        private readonly string APIKey;
        private readonly string APISecret;
        private readonly IAuthenticationService authenticationService;
        private readonly IElasticSearch elasticSearch;
        
        public PaymentService(IOptions<SCBApplication> SCBApplication, IAuthenticationService authenticationService, IElasticSearch elasticSearch) : base(SCBApplication.Value.SCBApiUr)
        {
            APIKey = SCBApplication.Value.APIKey;
            APISecret = SCBApplication.Value.APISecret;
            this.authenticationService = authenticationService;
            this.elasticSearch = elasticSearch;
        }

        public PaymentResponse DeeplinkTransactions(string customerId, CustomerResponse customer, PaymentRequest request, Header header)
        {
            header.apikey = APIKey;
            header.apisecret = APISecret;
            header.resourceOwnerId = customerId;

            WebClient webC = authenticationService.ConvertHeadertoWebClient(header);

            PaymentResponse response = Post<PaymentResponse, PaymentRequest> ("/v2/deeplink/transactions", request, webC);

            Transaction transaction = new Transaction
            {
                transactionId = response.data.transactionId,
                transaction = response,
                payment = request,
                customer = customer.data.profile,
            };

            elasticSearch.CreateJSONDocumentToIndex(transaction);

            return response;
        }
    }
}
