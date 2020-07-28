using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceTaxRates
    {
        public long TaxRateId { get; set; }
        public string TaxRateCountry { get; set; }
        public string TaxRateState { get; set; }
        public string TaxRate { get; set; }
        public string TaxRateName { get; set; }
        public long TaxRatePriority { get; set; }
        public int TaxRateCompound { get; set; }
        public int TaxRateShipping { get; set; }
        public long TaxRateOrder { get; set; }
        public string TaxRateClass { get; set; }
    }
}
