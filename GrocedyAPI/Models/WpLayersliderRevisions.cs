using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpLayersliderRevisions
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int Author { get; set; }
        public string Data { get; set; }
        public int DateC { get; set; }
    }
}
