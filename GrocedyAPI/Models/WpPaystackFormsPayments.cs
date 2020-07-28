using System;
using System.Collections.Generic;

namespace GrocedyAPI.Models
{
    public partial class WpPaystackFormsPayments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Metadata { get; set; }
        public int Paid { get; set; }
        public string Plan { get; set; }
        public string TxnCode { get; set; }
        public string TxnCode2 { get; set; }
        public string Amount { get; set; }
        public string Ip { get; set; }
        public string DeletedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset Modified { get; set; }
        public DateTimeOffset PaidAt { get; set; }
    }
}
