using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpUserpaymentsubcriptiondetails
    {
        public long Id { get; set; }
        public string SubscriptionId { get; set; }
        public string AuthorizationCode { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PaymentReference { get; set; }
    }
}
