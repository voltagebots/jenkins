using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWcDownloadLog
    {
        public long DownloadLogId { get; set; }
        public DateTime Timestamp { get; set; }
        public long PermissionId { get; set; }
        public long? UserId { get; set; }
        public string UserIpAddress { get; set; }
    }
}
