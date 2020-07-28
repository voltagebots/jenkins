using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpIcwpWpsfSessions
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string WpUsername { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public int LoggedInAt { get; set; }
        public int LastActivityAt { get; set; }
        public string LastActivityUri { get; set; }
        public string LiCodeEmail { get; set; }
        public int LoginIntentExpiresAt { get; set; }
        public int SecadminAt { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
