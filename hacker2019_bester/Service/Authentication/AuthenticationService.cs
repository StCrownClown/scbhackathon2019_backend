using hacker2019_bester.Configurations;
using hacker2019_bester.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net;

namespace hacker2019_bester.Service
{
    public class AuthenticationService : ExternalService, IAuthenticationService 
    {
        private readonly string APIKey;
        private readonly string APISecret;

        public AuthenticationService(IOptions<SCBApplication> SCBApplication) : base(SCBApplication.Value.SCBApiUr)
        {
            APIKey = SCBApplication.Value.APIKey;
            APISecret = SCBApplication.Value.APISecret;
        }

        public WebClient ConvertHeadertoWebClient(Header header)
        {
            WebClient webC = new WebClient();
            header.requestUId = Guid.NewGuid().ToString();
            webC.Headers["Content-Type"] = "application/json";
            webC.Headers["accept-language"] = "EN";
            webC.Headers["response-channel"] = "mobile";
            webC.Headers["endState"] = "mobile_app";
            webC.Headers["channel"] = "scbeasy";
            webC.Headers["authorization"] = header.authorization;
            webC.Headers["host"] = header.host;
            webC.Headers["resourceOwnerId"] = header.resourceOwnerId;
            webC.Headers["apikey"] = header.apikey;
            webC.Headers["apisecret"] = header.apisecret;
            webC.Headers["requestUId"] = header.requestUId;
            return webC;
        }

        public AuthenticationResponse GetOauthAuthorize(Header header)
        {
            header.apikey = APIKey;
            header.apisecret = APISecret;
            header.resourceOwnerId = APIKey;

            WebClient webC  = ConvertHeadertoWebClient(header);

            return Get<AuthenticationResponse> ("/v2/oauth/authorize", webC);
        }

        public AuthenticationResponse OAuthToken(Header header)
        {
            AuthenticationRequest request = new AuthenticationRequest
            {
                applicationKey = APIKey,
                applicationSecret = APISecret
            };
            header.resourceOwnerId = APIKey;

            WebClient webC = ConvertHeadertoWebClient(header);

            return Post<AuthenticationResponse, AuthenticationRequest> ("/v1/oauth/token", request, webC);
        }
    }
}
