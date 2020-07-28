using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpIcwpWpsfNotes
    {
        public int Id { get; set; }
        public string WpUsername { get; set; }
        public string Note { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
