using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfScanq
    {
        public int Id { get; set; }
        public string Scan { get; set; }
        public string Items { get; set; }
        public string Results { get; set; }
        public string Meta { get; set; }
        public int StartedAt { get; set; }
        public int FinishedAt { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
