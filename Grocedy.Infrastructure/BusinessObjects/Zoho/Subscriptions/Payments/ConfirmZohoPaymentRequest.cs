using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.Payments
{
    public class ConfirmZohoPaymentRequest
    {
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("payment_mode")]
        public string PaymentMode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        //[JsonProperty("date")]
        //public string Date { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("invoices")]
        public IList<Invoice> Invoices { get; set; }

        [JsonProperty("exchange_rate")]
        public int ExchangeRate { get; set; }

        [JsonProperty("bank_charges")]
        public int BankCharges { get; set; }

        [JsonProperty("tax_account_id")]
        public string TaxAccountId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }
    }



    public class Invoice
    {

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("amount_applied")]
        public decimal AmountApplied { get; set; }
    }
}
