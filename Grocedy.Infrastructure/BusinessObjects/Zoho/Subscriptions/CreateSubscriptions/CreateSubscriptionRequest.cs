using System;
namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class CreateSubscriptionRequest
    {
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string PlanCode { get; set; }
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public string CustomerName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BillingState { get; set; }
        public string BillingCity { get; set; }
        public string BillingStreet { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingPhoneNo { get; set; }
        public string Phone { get; set; }
        public bool IsRequestFromWebApp { get; set; }
        public bool IsGift { get; set; }
        public decimal Amount { get; set; }
        //public string BillingAddress1 { get; set; }
        //public string BillingAddress2 { get; set; }
        //public string ShippingAddress1 { get; set; }
        //public string ShippingAddress2 { get; set; }

        public string GiftCustomerName { get; set; }
        public string GiftFirstName { get; set; }
        public string GiftLastName { get; set; }
        public string GiftBillingState { get; set; }
        public string GiftBillingCity { get; set; }
        public string GiftBillingStreet { get; set; }
        public string GiftShippingState { get; set; }
        public string GiftShippingCity { get; set; }
        public string GiftShippingStreet { get; set; }
        public string GiftEmail { get; set; }
    }
}
