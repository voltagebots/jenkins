using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceShippingZones
    {
        public long ZoneId { get; set; }
        public string ZoneName { get; set; }
        public long ZoneOrder { get; set; }
    }
}
