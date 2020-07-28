using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceShippingZoneMethods
    {
        public long ZoneId { get; set; }
        public long InstanceId { get; set; }
        public string MethodId { get; set; }
        public long MethodOrder { get; set; }
        public byte IsEnabled { get; set; }
    }
}
