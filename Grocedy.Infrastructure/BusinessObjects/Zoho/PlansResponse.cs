using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Base;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho
{
    public class PlansResponse :BaseZohoResponse
    {
        public PlansResponse()
        {
        }

       

        [JsonProperty("plans")]
        public IList<Plan> Plans { get; set; }

        [JsonProperty("page_context")]
        public PageContext PageContext { get; set; }
    }

    //public class Addon
    //{

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("addon_code")]
    //    public string AddonCode { get; set; }
    //    [JsonProperty("price")]
    //    public int Price { get; set; }
    //}

    public class Plan
    {

        [JsonProperty("plan_code")]
        public string PlanCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("billing_mode")]
        public string BillingMode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        [JsonProperty("tax_name")]
        public string TaxName { get; set; }

        [JsonProperty("tax_percentage")]
        public int TaxPercentage { get; set; }

        [JsonProperty("tax_type")]
        public string TaxType { get; set; }

        [JsonProperty("trial_period")]
        public int TrialPeriod { get; set; }

        [JsonProperty("setup_fee")]
        public double SetupFee { get; set; }

        [JsonProperty("setup_fee_account_id")]
        public string SetupFeeAccountId { get; set; }

        [JsonProperty("setup_fee_account_name")]
        public string SetupFeeAccountName { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("recurring_price")]
        public double RecurringPrice { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }

        [JsonProperty("billing_cycles")]
        public int BillingCycles { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("show_in_widget")]
        public bool ShowInWidget { get; set; }

        [JsonProperty("store_description")]
        public string StoreDescription { get; set; }

        [JsonProperty("store_markup_description")]
        public string StoreMarkupDescription { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("created_time_formatted")]
        public string CreatedTimeFormatted { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("updated_time_formatted")]
        public string UpdatedTimeFormatted { get; set; }

        [JsonProperty("addons")]
        public IList<Addon> Addons { get; set; }

        [JsonProperty("custom_fields")]
        public IList<object> CustomFields { get; set; }
    }

    public class PageContext
    {

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("has_more_page")]
        public bool HasMorePage { get; set; }

        [JsonProperty("applied_filter")]
        public string AppliedFilter { get; set; }

        [JsonProperty("sort_column")]
        public string SortColumn { get; set; }

        [JsonProperty("sort_order")]
        public string SortOrder { get; set; }
    }
}
