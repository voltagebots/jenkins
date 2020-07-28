using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpLayerslider
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int Author { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Data { get; set; }
        public int DateC { get; set; }
        public int DateM { get; set; }
        public int ScheduleStart { get; set; }
        public int ScheduleEnd { get; set; }
        public byte FlagHidden { get; set; }
        public byte FlagDeleted { get; set; }
        public byte FlagPopup { get; set; }
        public byte FlagGroup { get; set; }
    }
}
