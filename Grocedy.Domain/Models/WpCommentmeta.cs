﻿using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpCommentmeta
    {
        public long MetaId { get; set; }
        public long CommentId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
