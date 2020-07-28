using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions
{
    public class Subscription
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty("plan_name")]
        public string PlanName { get; set; }

        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("activated_at")]
        public string ActivatedAt { get; set; }

        [JsonProperty("current_term_ends_at")]
        public string CurrentTermEndsAt { get; set; }

        [JsonProperty("current_term_starts_at")]
        public string CurrentTermStartsAt { get; set; }

        [JsonProperty("last_billing_at")]
        public string LastBillingAt { get; set; }

        [JsonProperty("next_billing_at")]
        public string NextBillingAt { get; set; }

        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }

        [JsonProperty("auto_collect")]
        public bool AutoCollect { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("salesperson_id")]
        public string SalespersonId { get; set; }

        [JsonProperty("salesperson_name")]
        public string SalespersonName { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("custom_fields")]
        public IList<CustomField> CustomFields { get; set; }

        [JsonProperty("last_shipment_order")]
        public string LastShipmentOrder { get; set; }

        [JsonProperty("last_shipment_order_id")]
        public string LastShipmentOrderID { get; set; }

        [JsonProperty("child_invoice_id")]
        public string ChildInvoiceID { get; set; }

        [JsonProperty("customer")]
        public CustomerResponse Customer { get; set; }


        public string Date { get; set; }
        public string StartMonth { get; set; }

        [JsonProperty("plan")]
        public Plan Plans { get; set; }
        [JsonProperty("addon")]
        public Addon Addons { get; set; }

        public string UserID { get; set; }
        public bool IsGift { get; set; }


    }
}
