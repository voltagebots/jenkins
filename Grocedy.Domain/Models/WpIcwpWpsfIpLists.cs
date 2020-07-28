using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfIpLists
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Label { get; set; }
        public string List { get; set; }
        public byte Ip6 { get; set; }
        public byte IsRange { get; set; }
        public short Transgressions { get; set; }
        public int LastAccessAt { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
        public int BlockedAt { get; set; }
    }
}
