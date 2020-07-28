using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfSpambotCommentsFilter
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UniqueToken { get; set; }
        public string Ip { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
