using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpPtsTables
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Label { get; set; }
        public int OriginalId { get; set; }
        public string Params { get; set; }
        public string Html { get; set; }
        public string Css { get; set; }
        public string Img { get; set; }
        public int SortOrder { get; set; }
        public byte IsBase { get; set; }
        public byte IsPro { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
