using System;
namespace GrocedyAPI.DataModels.Account
{
    public class ChangeDeliveryRequest
    {
        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingState { get; set; }
        public string BillingPhone { get; set; }
        public string BillingEmail { get; set; }
        public string UserID { get; set; }
        public string Landmark { get; set; }
        public string ShippingAddress1 { get; set; }
        public string ShippingAddress2 { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingLandmark { get; set; }
        public string Token { get; set; }
    }
}
