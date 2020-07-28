using System;
using Newtonsoft.Json;

namespace GrocedyAPI.Models
{
    public class ZohoToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
