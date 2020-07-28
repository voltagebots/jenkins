using System;
using GrocedyAPI.DataModels.Base;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho
{
    public class CreateCustomerRequest
    {
        public CreateCustomerRequest()
        {
        }

        [JsonProperty("mobile")]
        public string BillingPhone { get; set; }

        [JsonProperty("phone")]
        public string ShippingPhone { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }

    public class CreateCustomer
    {
        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }
    }

    public class CreateCustomerResponse:BaseZohoResponse
    {

    }
}
