using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class Addon
    {
        [JsonProperty("addon_code")]
        public string AddonCode { get; set; }

        [JsonProperty("addon_description")]
        public string AddonDescription { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        //[JsonProperty("tax_exemption_id")]
        //public string TaxExemptionId { get; set; }

        //[JsonProperty("tax_exemption_code")]
        //public string TaxExemptionCode { get; set; }


        [JsonProperty("plans")]
        public IList<Plan> Plans { get; set; }

        [JsonProperty("price_brackets")]
        public IList<PriceBracket> PriceBrackets { get; set; }

    }

    public class PriceBracket
    {

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
