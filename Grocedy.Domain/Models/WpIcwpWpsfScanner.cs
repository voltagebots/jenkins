using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfScanner
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Meta { get; set; }
        public string Scan { get; set; }
        public int Severity { get; set; }
        public int IgnoredAt { get; set; }
        public int NotifiedAt { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
