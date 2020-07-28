using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.WebHooks
{
    public class ChargePaymentResponse
    {
        public ChargePaymentResponse()
        {
        }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
