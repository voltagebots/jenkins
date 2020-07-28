using System;
namespace GrocedyAPI.DataModels.Zoho.Subscriptions.Deliveries
{
    public class    DeliveriesModel
    {
        public string  Title { get; set; }
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public string Date { get; set; }
        public string Basket { get; set; }
        public string SubscriptionID { get; set; }
        public string StartMonth { get; set; }
    }
}
