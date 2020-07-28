using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions
{
    public class UpdatePaymentReferenceRequest
    {
        [JsonProperty("custom_fields")]
        public IList<PaymentReferenceCustomField> CustomFields { get; set; }
    }


    public class PaymentReferenceCustomField:CustomField
    {

    }
}
