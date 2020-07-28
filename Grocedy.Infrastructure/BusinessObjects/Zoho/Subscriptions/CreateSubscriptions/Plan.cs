using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class Plan
    {
        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty("plan_description")]
        public string PlanDescription { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("setup_fee")]
        public decimal SetupFee { get; set; }

        [JsonProperty("setup_fee_tax_id")]
        public string SetupFeeTaxId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        //[JsonProperty("tax_exemption_id")]
        //public string TaxExemptionId { get; set; }

        //[JsonProperty("tax_exemption_code")]
        //public string TaxExemptionCode { get; set; }

        //[JsonProperty("setup_fee_tax_exemption_id")]
        //public string SetupFeeTaxExemptionId { get; set; }

        //[JsonProperty("setup_fee_tax_exemption_code")]
        //public string SetupFeeTaxExemptionCode { get; set; }

        [JsonProperty("exclude_trial")]
        public bool ExcludeTrial { get; set; }

        [JsonProperty("exclude_setup_fee")]
        public bool ExcludeSetupFee { get; set; }

        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }

        [JsonProperty("trial_days")]
        public int TrialDays { get; set; }
    }
}
