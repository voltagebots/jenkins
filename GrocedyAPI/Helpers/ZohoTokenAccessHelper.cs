using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GrocedyAPI.Models;
using Newtonsoft.Json;

namespace GrocedyAPI.Helpers
{
    public class ZohoTokenAccessHelper
    {
        public ZohoTokenAccessHelper()
        {

        }
        public static string RefreshToken { get; set; } = "1000.19caf2276508eca74595a6f89eb3655f.019937f3572c475ae07a86a4946f24cb";
        public async static Task<ZohoToken> Token()
        {

            var tokenURL = "https://accounts.zoho.com/oauth/v2/token?";

            HttpClient httpClient = new HttpClient();
            var result = await httpClient.PostAsync(tokenURL, new FormUrlEncodedContent(new[]
         {
                new KeyValuePair<string, string>("refresh_token", RefreshToken),
                new KeyValuePair<string, string>("client_id", "1000.Y7VD09YWFSG1BG9JALBUT75G6TLFYH"),
                new KeyValuePair<string, string>("client_secret", "f77022645ed56892d2014dddf56c969df0d85d9309"),
                new KeyValuePair<string, string>("redirect_uri", "https://grocedy.com/"),
                new KeyValuePair<string, string>("grant_type", "refresh_token")
                }));
            string resultContent = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ZohoToken>(resultContent);
        }
    }
}
