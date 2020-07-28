using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class CustomerResponse
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("salutation")]
        public string Salutation { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("payment_terms")]
        public int PaymentTerms { get; set; }

        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

      

        [JsonProperty("place_of_contact")]
        public string PlaceOfContact { get; set; }

        [JsonProperty("gst_no")]
        public string GstNo { get; set; }

        [JsonProperty("gst_treatment")]
        public string GstTreatment { get; set; }

        [JsonProperty("vat_treatment")]
        public string VatTreatment { get; set; }

        [JsonProperty("vat_reg_no")]
        public long VatRegNo { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("is_taxable")]
        public bool IsTaxable { get; set; }

        [JsonProperty("tax_id")]
        public string TaxId { get; set; }

        [JsonProperty("tax_authority_id")]
        public string TaxAuthorityId { get; set; }

        [JsonProperty("tax_authority_name")]
        public string TaxAuthorityName { get; set; }

        [JsonProperty("tax_exemption_id")]
        public string TaxExemptionId { get; set; }

        [JsonProperty("tax_exemption_code")]
        public string TaxExemptionCode { get; set; }
    }

    public class Customer
    {
       
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("salutation")]
        public string Salutation { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("customer_sub_type")]
        public string CustomerSubType { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty("payment_terms")]
        public int PaymentTerms { get; set; }

        [JsonProperty("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }

        //[JsonProperty("place_of_contact")]
        //public string PlaceOfContact { get; set; }

        //[JsonProperty("gst_no")]
        //public string GstNo { get; set; }

        //[JsonProperty("gst_treatment")]
        //public string GstTreatment { get; set; }

        //[JsonProperty("vat_treatment")]
        //public string VatTreatment { get; set; }

        //[JsonProperty("vat_reg_no")]
        //public long VatRegNo { get; set; }

        //[JsonProperty("country_code")]
        //public string CountryCode { get; set; }

        //[JsonProperty("is_taxable")]
        //public bool IsTaxable { get; set; }

        //[JsonProperty("tax_id")]
        //public string TaxId { get; set; }

        //[JsonProperty("tax_authority_id")]
        //public string TaxAuthorityId { get; set; }

        //[JsonProperty("tax_authority_name")]
        //public string TaxAuthorityName { get; set; }

        //[JsonProperty("tax_exemption_id")]
        //public string TaxExemptionId { get; set; }

        //[JsonProperty("tax_exemption_code")]
        //public string TaxExemptionCode { get; set; }
    }
}
