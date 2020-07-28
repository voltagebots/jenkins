using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.WebHooks
{
    public class RenewalSubscriptionWebHookRequest
    {
        
        
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("data")]
        public SubscriptionData Data { get; set; }

    }

    public class SubscriptionData
    {

        [JsonProperty("subscription")]
        public SubscriptionDetails Subscription { get; set; }
    }

    public class SubscriptionDetails
    {
       
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        [JsonProperty("child_invoice_id")]
        public string ChildInvoiceId { get; set; }

        [JsonProperty("customer")]
        public CustomerDetails Customer { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }


    }

    public class CustomerDetails
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
