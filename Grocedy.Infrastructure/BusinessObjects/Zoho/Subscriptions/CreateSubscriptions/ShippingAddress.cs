using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class ShippingAddress
    {
        [JsonProperty("attention")] 
        public string Attention { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public int Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}
