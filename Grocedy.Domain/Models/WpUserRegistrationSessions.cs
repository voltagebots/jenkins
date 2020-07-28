using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpUserRegistrationSessions
    {
        public long SessionId { get; set; }
        public string SessionKey { get; set; }
        public string SessionValue { get; set; }
        public long SessionExpiry { get; set; }
    }
}
