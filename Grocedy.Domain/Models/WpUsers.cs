﻿using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpUsers
    {
        public long Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public string UserNicename { get; set; }
        public string UserEmail { get; set; }
        public string UserUrl { get; set; }
        public DateTime UserRegistered { get; set; }
        public string UserActivationKey { get; set; }
        public int UserStatus { get; set; }
        public string DisplayName { get; set; }
    }
}
