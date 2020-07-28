using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Grocedy.Infrastructure.BusinessObjects;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Grocedy.Infrastructure.Infrastructure
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly IConfiguration configuration;
        public HttpClientFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<(TResult result, string token)> GetAsync<TResult>(string url, APIType apiType, string zohoToken)
        {
            var response = await MakeARequestForGet(url, apiType, zohoToken);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var serialized = await response.Content.ReadAsStringAsync();
                    TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));
                    return (result, token: string.Empty);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                if (apiType == APIType.ZohoSubscription)
                {
                    var token = Token(apiType).Result.AccessToken;
                    response = await MakeARequestForGet(url, apiType, token);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (result: JsonConvert.DeserializeObject<TResult>(responseString), token: token);
                    }
                    else
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (JsonConvert.DeserializeObject<TResult>(responseString), token: string.Empty);
                    }
                }
                if (apiType == APIType.ZohoInventory)
                {
                    var token = Token(apiType).Result.AccessToken;
                    response = await MakeARequestForGet(url, apiType, token);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (result: JsonConvert.DeserializeObject<TResult>(responseString), token: token);
                    }
                    else
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (JsonConvert.DeserializeObject<TResult>(responseString), token: string.Empty);
                    }
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<TResult>(responseString), token: string.Empty);
                }
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return (JsonConvert.DeserializeObject<TResult>(responseString), token: string.Empty);
            }

        }

        public async Task<(TResult result, string token)> PostAsync<TResult, TRequest>(string url, TRequest data, APIType apiType, string zohoToken)
        {
            try
            {
                var response = await MakeARequestForPost<TRequest>(url, data, apiType, zohoToken);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    if (apiType == APIType.ZohoSubscription)
                    {
                        var token = Token(apiType).Result.AccessToken;
                        response = await MakeARequestForPost<TRequest>(url, data, apiType, token);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), token);
                        }
                        else
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                        }
                    }
                    else if (apiType == APIType.ZohoInventory)
                    {
                        var token = Token(apiType).Result.AccessToken;
                        response = await MakeARequestForPost<TRequest>(url, data, apiType, token);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), token);
                        }
                        else
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                        }
                    }
                    else
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                    }
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                }
            }
            catch (Exception ex)
            {
                return (default(TResult), token: string.Empty);
            }

        }

        public async Task<(TResult result, string token)> PutAsync<TResult, TRequest>(string url, TRequest data, APIType apiType, string zohoToken)
        {
            try
            {
                var response = await MakeARequestForPut<TRequest>(url, data, apiType, zohoToken);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    if (apiType == APIType.ZohoSubscription)
                    {
                        var token = Token(apiType).Result.AccessToken;
                        response = await MakeARequestForPut<TRequest>(url, data, apiType, token);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), token);
                        }
                        else
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                        }
                    }
                    else if (apiType == APIType.ZohoInventory)
                    {
                        var token = Token(apiType).Result.AccessToken;
                        response = await MakeARequestForPut<TRequest>(url, data, apiType, token);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), token);
                        }
                        else
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                        }
                    }
                    else
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                    }
                }
                else
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return (JsonConvert.DeserializeObject<TResult>(responseString), string.Empty);
                }
            }
            catch (Exception ex)
            {
                return (default(TResult), token: string.Empty);
            }

        }

        private async Task<HttpResponseMessage> MakeARequestForGet(string url, APIType apiType, string zohoToken)
        {
            var client = GetHttpClient(apiType, zohoToken);
            return await client.GetAsync(url);
        }

        private async Task<HttpResponseMessage> MakeARequestForPost<TRequest>(string url, TRequest data, APIType apiType, string zohoToken)
        {
            var client = GetHttpClient(apiType, zohoToken);



            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }

        private async Task<HttpResponseMessage> MakeARequestForPut<TRequest>(string url, TRequest data, APIType apiType, string zohoToken)
        {
            var client = GetHttpClient(apiType, zohoToken);



            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PutAsync(url, content);
        }

        public HttpClient GetHttpClient(APIType apiType, string zohoToken)
        {
            var _handler = new HttpClientHandler();
            var httpClient = new HttpClient(_handler);
            httpClient.DefaultRequestHeaders.Accept.Clear();


            if (apiType == APIType.ZohoSubscription)
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Zoho-oauthtoken", zohoToken);
                httpClient.DefaultRequestHeaders.Add("X-com-zoho-subscriptions-organizationid", configuration.GetSection("ZohoSubscriptionOrganizationID").Value);
            }
            else if (apiType == APIType.ZohoInventory)
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Zoho-oauthtoken", zohoToken);
                httpClient.DefaultRequestHeaders.Add("X-com-zoho-inventory-organizationid", configuration.GetSection("ZohoSubscriptionOrganizationID").Value);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.configuration.GetSection("PaystackSecretKey").Value);
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public async Task<ZohoToken> Token(APIType apiType)
        {

            var tokenURL = "https://accounts.zoho.com/oauth/v2/token?";
            string refreshToken = string.Empty;
            if (apiType == APIType.ZohoSubscription)
                refreshToken = this.configuration.GetSection("ZohoSubscriptionRefreshToken").Value;
            if (apiType == APIType.ZohoInventory)
                refreshToken = this.configuration.GetSection("ZohoInventoryRefreshToken").Value;

            HttpClient httpClient = new HttpClient();
            var result = await httpClient.PostAsync(tokenURL, new FormUrlEncodedContent(new[]
         {
                new KeyValuePair<string, string>("refresh_token",refreshToken),
                new KeyValuePair<string, string>("client_id", this.configuration.GetSection("ZohoClientID").Value),
                new KeyValuePair<string, string>("client_secret", this.configuration.GetSection("ZohoClientSecret").Value),
                new KeyValuePair<string, string>("redirect_uri", "https://grocedy.com/"),
                new KeyValuePair<string, string>("grant_type", "refresh_token")
                }));
            string resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ZohoToken>(resultContent);
        }

        public enum APIType
        {
            ZohoSubscription = 0,
            ZohoInventory,
            Paystack
        }
    }
}
