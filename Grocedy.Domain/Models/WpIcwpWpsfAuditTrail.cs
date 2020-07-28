using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfAuditTrail
    {
        public int Id { get; set; }
        public string Rid { get; set; }
        public string Ip { get; set; }
        public string WpUsername { get; set; }
        public string Context { get; set; }
        public string Event { get; set; }
        public int Category { get; set; }
        public string Message { get; set; }
        public string Meta { get; set; }
        public byte Immutable { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
        public short Count { get; set; }
        public int UpdatedAt { get; set; }
    }
}
