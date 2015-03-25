using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobiliTips.MvxPlugin.MvxAms.Api
{
    public interface IMvxAmsApiService
    {
        Task<T> InvokeApiAsync<T>(string apiName);
        Task<U> InvokeApiAsync<T, U>(string apiName, T body);
        Task<T> InvokeApiAsync<T>(string apiName, HttpMethod method, IDictionary<string, string> parameters);
        Task<U> InvokeApiAsync<T, U>(string apiName, T body, HttpMethod method, IDictionary<string, string> parameters);
        Task<HttpResponseMessage> InvokeApiAsync(string apiName, HttpContent content, HttpMethod method, IDictionary<string, string> requestHeaders, IDictionary<string, string> parameters);
    }
}
