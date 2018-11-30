namespace OIDCSampleApplication.Utilities
{
    public static class Constants
    {
        public const string OIDCConfig = "OIDCConfig";
        public const string ClientId = "ClientId";
        public const string ClientSecret = "ClientSecret";
        public const string Authority = "Authority";
        public const string Cookies = "Cookies";
        public const string Oidc = "oidc";
        //For Only Authorization Flow,  it should be public const string ResponseType = "code";
        //For Only Implicit Flow, it should be public const string ResponseType = "id_token";
        public const string ResponseType = "code id_token";
        public const string Openid = "openid";
        public const string Profile = "profile";
    }
}
