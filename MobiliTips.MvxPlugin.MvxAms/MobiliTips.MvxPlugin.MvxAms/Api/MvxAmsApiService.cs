using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms.Api
{
    public class MvxAmsApiService : IMvxAmsApiService
    {
        private readonly MobileServiceClient _client;
        private readonly IMvxMessenger _messenger;

        public MvxAmsApiService(MobileServiceClient client)
        {
            _client = client;
            _messenger = Mvx.Resolve<IMvxMessenger>();
        }

        public async Task<T> InvokeApiAsync<T>(string apiName)
        {
            try
            {
                return await _client.InvokeApiAsync<T>(apiName);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return default(T);
            }
        }

        public async Task<U> InvokeApiAsync<T, U>(string apiName, T body)
        {
            try
            {
                return await _client.InvokeApiAsync<T, U>(apiName, body);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return default(U);
            }
        }

        public async Task<T> InvokeApiAsync<T>(string apiName, HttpMethod method, IDictionary<string, string> parameters)
        {
            try
            {
                return await _client.InvokeApiAsync<T>(apiName, method, parameters);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return default(T);
            }
        }

        public async Task<U> InvokeApiAsync<T, U>(string apiName, T body, HttpMethod method, IDictionary<string, string> parameters)
        {
            try
            {
                return await _client.InvokeApiAsync<T, U>(apiName, body, method, parameters);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return default(U);
            }
        }

        public async Task<HttpResponseMessage> InvokeApiAsync(string apiName, HttpContent content, HttpMethod method, IDictionary<string, string> requestHeaders,
            IDictionary<string, string> parameters)
        {
            try
            {
                return await _client.InvokeApiAsync(apiName, content, method, requestHeaders, parameters);
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                _messenger.Publish(new MvxAmsErrorMessage(this, ex));
                return null;
            }
        }
    }
}