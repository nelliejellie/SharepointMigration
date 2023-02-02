using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SharePointMigration.Service
{
    public interface ITokenService
    {
        Task<AuthenticationResult> AuthenticateOnBehalfOf(params string[] scopes);
        Task<string> AcquireTokenOnBehalfOf(params string[] scopes);
        Task<Dictionary<string, object>> GetMsalBrowserCache(params string[] scopes);
    }

    public class TokenService : ITokenService
    {
        private string _currentToken;
        private readonly IConfidentialClientApplication _app;

        public TokenService(IHttpContextAccessor httpContextAccessor, IConfidentialClientApplication app)
        {
            //_currentToken = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
            _app = app;
        }

        public async Task<AuthenticationResult> AuthenticateOnBehalfOf(params string[] scopes)
        {
            var userAssertion = new UserAssertion(
                _currentToken.Replace("Bearer ", ""),
                "urn:ietf:params:oauth:grant-type:jwt-bearer"
            );
            return await _app.AcquireTokenOnBehalfOf(scopes, userAssertion).ExecuteAsync();
        }

        public async Task<string> AcquireTokenOnBehalfOf(params string[] scopes)
        {
            var authenticationResult = await AuthenticateOnBehalfOf(scopes);

            return authenticationResult?.AccessToken;
        }

        public async Task<Dictionary<string, object>> GetMsalBrowserCache(params string[] scopes)
        {
            var auth = await AuthenticateOnBehalfOf(scopes);

            var accessor = Type.GetType("Microsoft.Identity.Client.ITokenCacheInternal, Microsoft.Identity.Client").GetProperty("Accessor").GetValue(_app.UserTokenCache);

            var fields = new string[] { "_accessTokenCacheDictionary", "_accountCacheDictionary", "_idTokenCacheDictionary", "_refreshTokenCacheDictionary" };
            var dicts = fields.Select(field => (IDictionary)accessor.GetType().GetField(field, BindingFlags.NonPublic | BindingFlags.Instance).GetValue(accessor));

            return dicts.SelectMany(dict => CastDict(dict).Where(kvp => ((string)kvp.Key).StartsWith(auth.Account.HomeAccountId.Identifier))).ToDictionary(o => (string)o.Key, o => o.Value);
        }

        private IEnumerable<DictionaryEntry> CastDict(IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                yield return entry;
            }
        }
    }
}