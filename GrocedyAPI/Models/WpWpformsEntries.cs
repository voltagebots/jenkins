using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWpformsEntries
    {
        public long EntryId { get; set; }
        public long FormId { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public byte? Viewed { get; set; }
        public byte? Starred { get; set; }
        public string Fields { get; set; }
        public string Meta { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateModified { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string UserUuid { get; set; }
    }
}
