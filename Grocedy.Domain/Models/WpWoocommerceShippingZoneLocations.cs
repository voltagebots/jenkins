﻿using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceShippingZoneLocations
    {
        public long LocationId { get; set; }
        public long ZoneId { get; set; }
        public string LocationCode { get; set; }
        public string LocationType { get; set; }
    }
}
