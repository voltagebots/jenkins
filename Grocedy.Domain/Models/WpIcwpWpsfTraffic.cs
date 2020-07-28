using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpIcwpWpsfTraffic
    {
        public int Id { get; set; }
        public string Rid { get; set; }
        public int Uid { get; set; }
        public byte[] Ip { get; set; }
        public string Path { get; set; }
        public int Code { get; set; }
        public string Verb { get; set; }
        public string Ua { get; set; }
        public byte Trans { get; set; }
        public int CreatedAt { get; set; }
        public int DeletedAt { get; set; }
    }
}
