using RestSharp.Authenticators;

namespace KeyPay.Auth
{
    public class OAuthAuthenticationDetails : AuthenticationDetails
    {
        private string AccessToken { get; set; }
        private string RefreshToken { get; set; }

        public OAuthAuthenticationDetails(
            string accessToken,
            string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public override IAuthenticator Authenticator => new OAuth2AuthorizationRequestHeaderAuthenticator(AccessToken, "Bearer");
    }
}