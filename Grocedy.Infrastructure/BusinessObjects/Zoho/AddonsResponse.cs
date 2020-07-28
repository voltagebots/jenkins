using System;
using System.Collections.Generic;
using GrocedyAPI.DataModels.Base;
using GrocedyAPI.DataModels.Zoho.Subscriptions.CreateSubscriptions;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho
{
    public class AddonsResponse:BaseZohoResponse
    {
        [JsonProperty("addons")]
        public IList<Addon> Addons { get; set; }
    }
}
