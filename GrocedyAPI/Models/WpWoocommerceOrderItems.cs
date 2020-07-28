using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWoocommerceOrderItems
    {
        public long OrderItemId { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemType { get; set; }
        public long OrderId { get; set; }
    }
}
