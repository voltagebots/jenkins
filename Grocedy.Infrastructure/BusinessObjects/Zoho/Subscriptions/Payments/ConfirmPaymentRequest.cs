using System;
namespace GrocedyAPI.DataModels.Zoho.Subscriptions.Payments
{
    public class ConfirmPaymentRequest
    {
        public string UserId { get; set; }
        public string Amount { get; set; }
        public string PaymentMode { get; set; }
        public string ReferenceNumber { get; set; }
        public string InvoiceID { get; set; }
        public string InvoiceDate { get; set; }
        public string CustomerID { get; set; }
        public string SubscriptionID { get; set; }

    }
}
