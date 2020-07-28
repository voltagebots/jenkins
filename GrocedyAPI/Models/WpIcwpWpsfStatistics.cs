using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpIcwpWpsfStatistics
    {
        public int Id { get; set; }
        public string StatKey { get; set; }
        public string ParentStatKey { get; set; }
        public int Tally { get; set; }
        public int CreatedAt { get; set; }
        public int ModifiedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
