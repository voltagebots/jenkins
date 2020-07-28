using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWoocommerceDownloadableProductPermissions
    {
        public long PermissionId { get; set; }
        public string DownloadId { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public string OrderKey { get; set; }
        public string UserEmail { get; set; }
        public long? UserId { get; set; }
        public string DownloadsRemaining { get; set; }
        public DateTime AccessGranted { get; set; }
        public DateTime? AccessExpires { get; set; }
        public long DownloadCount { get; set; }
    }
}
