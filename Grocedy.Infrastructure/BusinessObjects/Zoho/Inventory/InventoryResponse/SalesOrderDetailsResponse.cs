using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Inventory.InventoryResponse
{
    public class SalesOrderDetailsResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("salesorder")]
        public SalesOrderDetailsResponseModel Salesorder { get; set; }
    }
}
