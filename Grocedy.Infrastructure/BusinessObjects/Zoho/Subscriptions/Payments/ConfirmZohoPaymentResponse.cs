using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Base;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.Payments
{
    public class ConfirmZohoPaymentResponse:BaseZohoResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("payment")]
        public Payment Payment { get; set; }
    }

    public class Payment
    {

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("payment_mode")]
        public string PaymentMode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("amount_refunded")]
        public decimal AmountRefunded { get; set; }

        [JsonProperty("bank_charges")]
        public decimal BankCharges { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("autotransaction")]
        public Autotransaction Autotransaction { get; set; }

        [JsonProperty("invoices")]
        public IList<PaymentInvoice> Invoices { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        //[JsonProperty("custom_fields")]
        //public IList<CustomField> CustomFields { get; set; }
    }
    public class Autotransaction
    {

        [JsonProperty("autotransaction_id")]
        public string AutotransactionId { get; set; }

        [JsonProperty("payment_gateway")]
        public string PaymentGateway { get; set; }

        [JsonProperty("gateway_transaction_id")]
        public string GatewayTransactionId { get; set; }

        [JsonProperty("gateway_error_message")]
        public string GatewayErrorMessage { get; set; }

        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("last_four_digits")]
        public int LastFourDigits { get; set; }

        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }
    }

    public class PaymentInvoice
    {

        [JsonProperty("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("invoice_amount")]
        public decimal InvoiceAmount { get; set; }

        [JsonProperty("amount_applied")]
        public decimal AmountApplied { get; set; }

        [JsonProperty("balance_amount")]
        public decimal BalanceAmount { get; set; }
    }
}
