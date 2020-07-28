using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWcsPaymentRetries
    {
        public long RetryId { get; set; }
        public long OrderId { get; set; }
        public string Status { get; set; }
        public DateTime DateGmt { get; set; }
        public string RuleRaw { get; set; }
    }
}
