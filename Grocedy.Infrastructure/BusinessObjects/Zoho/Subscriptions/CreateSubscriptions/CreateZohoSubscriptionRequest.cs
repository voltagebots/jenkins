using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class CreateZohoSubscriptionRequest
    {
        [JsonProperty("customer_id")]
        public string CustomerID { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }
    
        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }
        [JsonProperty("custom_fields")]
        public IList<CustomField> CustomFields { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("addons")]
        public IList<Addon> Addons { get; set; }

        [JsonProperty("coupon_code")]
        public string CouponCode { get; set; }

        [JsonProperty("auto_collect")]
        public bool AutoCollect { get; set; }

    }
    public class CustomField
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
