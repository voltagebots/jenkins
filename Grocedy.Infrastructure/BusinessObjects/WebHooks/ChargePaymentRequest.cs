using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.WebHooks
{
    public class ChargePaymentRequest
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        [JsonProperty("reference")]
        public string ReferenceNumber { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
