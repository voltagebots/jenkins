using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Base;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class CreateZohoSubscriptionResponse:BaseZohoResponse
    {
        //[JsonProperty("code")]
        //public int Code { get; set; }

        //[JsonProperty("message")]
        //public string Message { get; set; }

        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
    }

    public class Subscription
    {

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

        [JsonProperty("current_term_starts_at")]
        public string CurrentTermStartsAt { get; set; }

        [JsonProperty("current_term_ends_at")]
        public string CurrentTermEndsAt { get; set; }

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

        [JsonProperty("place_of_supply")]
        public string PlaceOfSupply { get; set; }

        [JsonProperty("salesperson_id")]
        public string SalespersonId { get; set; }

        [JsonProperty("salesperson_name")]
        public string SalespersonName { get; set; }

        [JsonProperty("child_invoice_id")]
        public string ChildInvoiceId { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("end_of_term")]
        public bool EndOfTerm { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("addons")]
        public IList<Addon> Addons { get; set; }

        //[JsonProperty("coupon")]
        //public Coupon Coupon { get; set; }

        //[JsonProperty("card")]
        //public Card Card { get; set; }

        [JsonProperty("payment_terms")]
        public int PaymentTerms { get; set; }

        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

        [JsonProperty("can_add_bank_account")]
        public bool CanAddBankAccount { get; set; }

        [JsonProperty("customer")]
        public CustomerResponse Customer { get; set; }

      

        [JsonProperty("unbilled_charge_id")]
        public string UnbilledChargeId { get; set; }
    }


}
