﻿using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWoocommerceOrderItemmeta
    {
        public long MetaId { get; set; }
        public long OrderItemId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
