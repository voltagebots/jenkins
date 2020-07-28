using System;
using System.Collections.Generic;

namespace Grocedy.Domain.Models
{
    public partial class WpWcProductMetaLookup
    {
        public long ProductId { get; set; }
        public string Sku { get; set; }
        public byte? Virtual { get; set; }
        public byte? Downloadable { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public byte? Onsale { get; set; }
        public double? StockQuantity { get; set; }
        public string StockStatus { get; set; }
        public long? RatingCount { get; set; }
        public decimal? AverageRating { get; set; }
        public long? TotalSales { get; set; }
    }
}
