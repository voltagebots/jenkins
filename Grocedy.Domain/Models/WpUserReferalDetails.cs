using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpUserReferalDetails
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string ReferalCode { get; set; }
        public string TotalEarnings { get; set; }
        public string Balance { get; set; }
        public int? CurrentSignUpsFromLastIntervalClaim { get; set; }
    }
}
