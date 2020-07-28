using System.Threading.Tasks;
using Grocedy.Infrastructure.BusinessObjects;
using static Grocedy.Infrastructure.Infrastructure.HttpClientFactory;

namespace Grocedy.Infrastructure.Infrastructure
{
    public interface IHttpClientFactory
    {
        Task<(TResult result, string token)> GetAsync<TResult>(string url, HttpClientFactory.APIType apiType, string zohoToken);
        Task<(TResult result, string token)> PostAsync<TResult, TRequest>(string url, TRequest data, HttpClientFactory.APIType apiType, string zohoToken);
        Task<(TResult result, string token)> PutAsync<TResult, TRequest>(string url, TRequest data, HttpClientFactory.APIType apiType, string zohoToken);
        Task<ZohoToken> Token(APIType apiType);
    }
}