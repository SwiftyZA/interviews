using BusinessLayer.Enums;

namespace BusinessLayer.Models
{
    public class Price
    {
        public string SellingPrice { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
    }
}