    using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Base;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Subscriptions
{
    public class GetSubscriptionsResponse:BaseZohoResponse
    {
        

        [JsonProperty("subscriptions")]
        public IList<Subscription> Subscriptions { get; set; }
    }

    public class GetSubscriptionResponse : BaseZohoResponse
    {


        [JsonProperty("subscription")]
        public Subscription Subscription { get; set; }
    }
}
