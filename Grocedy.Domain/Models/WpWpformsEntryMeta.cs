using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWpformsEntryMeta
    {
        public long Id { get; set; }
        public long EntryId { get; set; }
        public long FormId { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
    }
}
