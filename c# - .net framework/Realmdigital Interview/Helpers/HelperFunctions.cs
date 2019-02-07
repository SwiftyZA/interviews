using BusinessLayer.Enums;
using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Realmdigital_Interview.Helpers
{
    internal static class ProductHelperFunctions
    {
        internal static void FilterPricesByCurrency(IEnumerable<Product> products, CurrencyCode currencyCode)
        {
            products = products.Select(x => { x.PriceRecords = x.PriceRecords.Where(y => y.CurrencyCode == currencyCode); return x; }).ToList();
        }

        internal static void FilterPricesByCurrency(Product product, CurrencyCode currencyCode)
        {
            product.PriceRecords = product.PriceRecords.Where(y => y.CurrencyCode == currencyCode);
        }
    }
}