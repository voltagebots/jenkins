using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpYoastSeoMeta
    {
        public long ObjectId { get; set; }
        public int? InternalLinkCount { get; set; }
        public int? IncomingLinkCount { get; set; }
    }
}
