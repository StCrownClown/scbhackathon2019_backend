using hacker2019_bester.Models;
using System.Net;

namespace hacker2019_bester.Service
{
    public interface IAuthenticationService
    {
        AuthenticationResponse GetOauthAuthorize(Header header);
        AuthenticationResponse OAuthToken(Header header);
        WebClient ConvertHeadertoWebClient(Header header);
    }
}
