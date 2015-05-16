using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cirrious.CrossCore;

namespace MobiliTips.MvxPlugins.MvxAms.Identity
{
    /// <summary>
    /// DelegatingHandler to automaticaly login user again if its auth token expired
    /// </summary>
    public class MvxAmsIdentityHandler : DelegatingHandler
    {
        private IMvxAmsCredentialsCacheService _credentialsCacheService;
        private IMvxAmsCredentials _credentials;
        private IMvxAmsService _azureMobileService;
        private MvxAmsAuthenticationProvider _provider;

        public MvxAmsIdentityHandler(MvxAmsAuthenticationProvider defaultProvider)
        {
            _provider = defaultProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Resolve IMvxAmsService if not yet defined
                if (_azureMobileService == null && !Mvx.TryResolve(out _azureMobileService))
                {
                    throw new InvalidOperationException("Make sure to configure MvxAms plugin properly before using it.");
                }

                // Cloning the request
                var clonedRequest = await CloneRequest(request);

                // Load saved user if possible
                if (Mvx.TryResolve(out _credentialsCacheService) 
                    && _credentialsCacheService.TryLoadCredentials(out _credentials)
                    && (_azureMobileService.Identity.CurrentUser == null
                    || (_azureMobileService.Identity.CurrentUser.UserId != _credentials.User.UserId
                    && _azureMobileService.Identity.CurrentUser.MobileServiceAuthenticationToken != _credentials.User.MobileServiceAuthenticationToken)))
                {
                    _azureMobileService.Identity.CurrentUser = _credentials.User;
                    _provider = _credentials.Provider;

                    clonedRequest.Headers.Remove("X-ZUMO-AUTH");
                    // Set the authentication header
                    clonedRequest.Headers.Add("X-ZUMO-AUTH", _credentials.User.MobileServiceAuthenticationToken);

                    // Resend the request
                    response = await base.SendAsync(clonedRequest, cancellationToken);
                } 

                if (response.StatusCode == HttpStatusCode.Unauthorized 
                    && _provider != MvxAmsAuthenticationProvider.None
                    && _provider != MvxAmsAuthenticationProvider.EmailPassword)
                {
                    if (_credentials != null)
                        _provider = _credentials.Provider;

                    try
                    {
                        // Login user again
                        var user = await _azureMobileService.Identity.LoginAsync(_provider);

                        // Save the user if possible
                        if (_credentialsCacheService != null)
                        {
                            if (_credentials == null) _credentials = new MvxAmsCredentials();
                            _credentials.User = user;
                            _credentials.Provider = _provider;
                            _credentialsCacheService.SaveCredentials(_credentials); 
                        }

                        clonedRequest.Headers.Remove("X-ZUMO-AUTH");
                        // Set the authentication header
                        clonedRequest.Headers.Add("X-ZUMO-AUTH", user.MobileServiceAuthenticationToken);

                        // Resend the request
                        response = await base.SendAsync(clonedRequest, cancellationToken);
                    }
                    catch (InvalidOperationException)
                    {
                        // user cancelled auth, so lets return the original response
                        return response;
                    }
                }
            }

            return response;
        }

        private async Task<HttpRequestMessage> CloneRequest(HttpRequestMessage request)
        {
            var result = new HttpRequestMessage(request.Method, request.RequestUri);
            foreach (var header in request.Headers)
            {
                result.Headers.Add(header.Key, header.Value);
            }

            if (request.Content != null && request.Content.Headers.ContentType != null)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                var mediaType = request.Content.Headers.ContentType.MediaType;
                result.Content = new StringContent(requestBody, Encoding.UTF8, mediaType);
                foreach (var header in request.Content.Headers)
                {
                    if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        result.Content.Headers.Add(header.Key, header.Value);
                    }
                }
            }

            return result;
        }
    }
}
