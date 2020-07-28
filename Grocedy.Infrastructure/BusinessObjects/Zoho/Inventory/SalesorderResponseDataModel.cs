using System;
using Newtonsoft.Json;

namespace GrocedyAPI.DataModels.Zoho.Inventory
{
    public class SalesorderResponseDataModel
    {
        [JsonProperty("salesorder_id")]
        public long SalesorderId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("salesorder_number")]
        public string SalesorderNumber { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("shipment_date")]
        public string ShipmentDate { get; set; }

        [JsonProperty("shipment_days")]
        public string ShipmentDays { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("quantity_invoiced")]
        public string QuantityInvoiced { get; set; }

        [JsonProperty("quantity_packed")]
        public string QuantityPacked { get; set; }

        [JsonProperty("quantity_shipped")]
        public string QuantityShipped { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("bcy_total")]
        public string BcyTotal { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("last_modified_time")]
        public string LastModifiedTime { get; set; }

        [JsonProperty("is_emailed")]
        public string IsEmailed { get; set; }

        [JsonProperty("is_drop_shipment")]
        public string IsDropShipment { get; set; }

        [JsonProperty("is_backorder")]
        public string IsBackorder { get; set; }

        [JsonProperty("sales_channel")]
        public string SalesChannel { get; set; }
    }
}
