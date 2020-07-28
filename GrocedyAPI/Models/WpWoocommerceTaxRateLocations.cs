using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWoocommerceTaxRateLocations
    {
        public long LocationId { get; set; }
        public string LocationCode { get; set; }
        public long TaxRateId { get; set; }
        public string LocationType { get; set; }
    }
}
