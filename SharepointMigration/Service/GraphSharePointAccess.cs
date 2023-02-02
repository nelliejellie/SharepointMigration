using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using SharePointMigration.Helper;
using System.Collections.Generic;

namespace SharePointMigration.Service
{
    public abstract class GraphSharePointAccess
    {
        protected readonly IMemoryCache _memoryCache;
        protected readonly GraphServiceClient _graphServiceClient;

        private string[] _scopes = new[] { "https://graph.microsoft.com/Sites.Read.All", "Sites.Read.All" };


        public GraphSharePointAccess(ITokenService tokenService, IConfiguration config, IMemoryCache memoryCache)
        {
            //_graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider(async (HttpRequestMessage) =>
            //{
            //    HttpRequestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await tokenService.AcquireTokenOnBehalfOf(_scopes));
            //}));
            var authenticationProvider = CreateAuthorizationProvider(config);
            _graphServiceClient = new GraphServiceClient(authenticationProvider);

            _memoryCache = memoryCache;
        }

        private IAuthenticationProvider CreateAuthorizationProvider(IConfiguration config)
        {
            var clientId = config["ErpApiClientId"];
            var clientSecret = config["ErpApiSecret"];
            var redirectUri = config["redirectUri"];
            var authority = $"https://login.microsoftonline.com/{config["ErpApiTenentId"]}/v2.0";
            //this specific scope means that application will default to what is defined in the application registration rather than using dynamic scopes
            List<string> scopes = new List<string>();
            scopes.Add("https://graph.microsoft.com/.default");

            var cca = ConfidentialClientApplicationBuilder.Create(clientId)
                                                    .WithAuthority(authority)
                                                    .WithRedirectUri(redirectUri)
                                                    .WithClientSecret(clientSecret)
                                                    .Build();
            return new MsalAuthenticationProvider(cca, scopes.ToArray());
        }
    }
}
