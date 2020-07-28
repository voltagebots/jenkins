using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceApiKeys
    {
        public long KeyId { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Permissions { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Nonces { get; set; }
        public string TruncatedKey { get; set; }
        public DateTime? LastAccess { get; set; }
    }
}
