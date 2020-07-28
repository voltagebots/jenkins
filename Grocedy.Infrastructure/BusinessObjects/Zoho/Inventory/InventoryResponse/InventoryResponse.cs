using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Inventory.InventoryResponse
{
    public class InventoryResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("salesorders")]
        public IList<SalesorderResponseDataModel> Salesorders { get; set; }
    }
}
