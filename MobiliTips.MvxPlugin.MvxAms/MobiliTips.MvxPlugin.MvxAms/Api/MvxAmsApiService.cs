using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MobiliTips.MvxPlugin.MvxAms.Api
{
    public class MvxAmsApiService : IMvxAmsApiService
    {
        private readonly MobileServiceClient _client;

        public MvxAmsApiService(MobileServiceClient client)
        {
            _client = client;
        }

        public Task<T> InvokeApiAsync<T>(string apiName)
        {
            throw new System.NotImplementedException();
        }

        public Task<U> InvokeApiAsync<T, U>(string apiName, T body)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> InvokeApiAsync<T>(string apiName, HttpMethod method, IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<U> InvokeApiAsync<T, U>(string apiName, T body, HttpMethod method, IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public Task<HttpResponseMessage> InvokeApiAsync(string apiName, HttpContent content, HttpMethod method, IDictionary<string, string> requestHeaders,
            IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}