using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceOrderItems
    {
        public long OrderItemId { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemType { get; set; }
        public long OrderId { get; set; }
    }
}
