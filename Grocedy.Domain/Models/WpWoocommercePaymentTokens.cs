using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommercePaymentTokens
    {
        public long TokenId { get; set; }
        public string GatewayId { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public string Type { get; set; }
        public byte IsDefault { get; set; }
    }
}
