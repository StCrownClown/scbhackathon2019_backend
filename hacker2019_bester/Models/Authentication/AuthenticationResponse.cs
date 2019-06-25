namespace hacker2019_bester.Models
{

    public class AuthenticationResponse : BaseResponse
    {
        public Token data {get; set;}
    }

    public class Token
    {
        public string accessToken { get; set; }

        public string tokenType { get; set; }

        public long expiresIn { get; set; }

        public long expiresAt { get; set; }

        public string refreshToken { get; set; }

        public long refreshExpiresIn { get; set; }

        public long refreshExpiresAt { get; set; }

        public string callbackUrl { get; set; }
    }
}
