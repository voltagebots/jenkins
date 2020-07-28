using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpZohocustomerMapping
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string ZohoCustomerId { get; set; }
    }
}
