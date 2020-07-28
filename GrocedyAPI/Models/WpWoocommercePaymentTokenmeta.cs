using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWoocommercePaymentTokenmeta
    {
        public long MetaId { get; set; }
        public long PaymentTokenId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
