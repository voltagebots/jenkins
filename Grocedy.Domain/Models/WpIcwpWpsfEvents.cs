using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfEvents
    {
        public int Id { get; set; }
        public string Event { get; set; }
        public int Count { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
