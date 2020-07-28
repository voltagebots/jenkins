using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWcTaxRateClasses
    {
        public long TaxRateClassId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
