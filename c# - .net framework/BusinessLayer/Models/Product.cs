using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class Product
    {
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public IEnumerable<Price> PriceRecords { get; set; }
    }
}