using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpWpformsEntryFields
    {
        public long Id { get; set; }
        public long EntryId { get; set; }
        public long FormId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
    }
}
