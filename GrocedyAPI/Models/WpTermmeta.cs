﻿using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpTermmeta
    {
        public long MetaId { get; set; }
        public long TermId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
    }
}
