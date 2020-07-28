using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Base
{
    public class BaseZohoResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

    }
}
