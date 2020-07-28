using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.WebHooks
{
    public class PaystackPaymentUpdateHookRequest
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("data")]
        public PaystackPaymentUpdateData Data { get; set; }
    }

    public class PaystackPaymentUpdateData
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("authorization")]
        public Authorization Authorization { get; set; }

        [JsonProperty("requested_amount")]
        public int RequestedAmount { get; set; }
    }

    public class Authorization
    {

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
    }
}
