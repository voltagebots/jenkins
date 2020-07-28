using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpIcwpWpsfGeoip
    {
        public int Id { get; set; }
        public byte[] Ip { get; set; }
        public string Meta { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
