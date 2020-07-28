using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpUserreferalsMappings
    {
        public long Id { get; set; }
        public string ReferedBy { get; set; }
        public string RegisteredUserId { get; set; }
        public short IsAccepted { get; set; }
        public long? TotalSubscriptions { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
