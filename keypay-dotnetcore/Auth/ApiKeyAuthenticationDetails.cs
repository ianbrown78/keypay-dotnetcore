using RestSharp.Authenticators;

namespace KeyPay.Auth
{
    public class ApiKeyAuthenticationDetails : AuthenticationDetails
    {
        public string ApiKey { get; set; }

        public ApiKeyAuthenticationDetails(string apiKey)
        {
            ApiKey = apiKey;
        }

        public override IAuthenticator Authenticator => new HttpBasicAuthenticator(ApiKey, "");
    }
}