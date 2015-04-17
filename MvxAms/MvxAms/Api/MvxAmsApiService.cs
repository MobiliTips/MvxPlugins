using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugins.MvxAms.Api
{
    public class MvxAmsApiService : IMvxAmsApiService
    {
        private readonly MobileServiceClient _client;

        public MvxAmsApiService(MobileServiceClient client)
        {
            _client = client;
        }

        public async Task<T> InvokeApiAsync<T>(string apiName)
        {
            return await _client.InvokeApiAsync<T>(apiName);
        }

        public async Task<U> InvokeApiAsync<T, U>(string apiName, T body)
        {
            return await _client.InvokeApiAsync<T, U>(apiName, body);
        }

        public async Task<T> InvokeApiAsync<T>(string apiName, HttpMethod method, IDictionary<string, string> parameters)
        {
            return await _client.InvokeApiAsync<T>(apiName, method, parameters);
        }

        public async Task<U> InvokeApiAsync<T, U>(string apiName, T body, HttpMethod method, IDictionary<string, string> parameters)
        {
            return await _client.InvokeApiAsync<T, U>(apiName, body, method, parameters);
        }

        public async Task<HttpResponseMessage> InvokeApiAsync(string apiName, HttpContent content, HttpMethod method, IDictionary<string, string> requestHeaders,
            IDictionary<string, string> parameters)
        {
            return await _client.InvokeApiAsync(apiName, content, method, requestHeaders, parameters);
        }
    }
}