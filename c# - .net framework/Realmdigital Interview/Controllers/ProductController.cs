using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;

namespace Realmdigital_Interview.Controllers
{
    public class ProductController
    {
        // Typically business logic should reside in the controller, but past experience has taught me to be cautious with the code you choose
        // to put here as it could easily bloat the class into an monolithic object that is hard for other devs to pick up and modify. I deemed
        // the price filtering to be relevant here for reasons explained below.

        IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [Route("product")]
        public async Task<Product> GetProductById(string productId)
        {
            var result = await _service.GetProductById(productId);

            // I'm unsure why the prices are being filtered here, I'm making the asumption that the filter is specific to the view.
            // If it was a global business requirement I'd put it in the ProductService.
            Helpers.ProductHelperFunctions.FilterPricesByCurrency(result, CurrencyCode.ZAR);
            
            return result;
        }

        [Route("product/search")]
        public async Task<IEnumerable<Product>> GetProductsByName(string productName)
        {
            var results = await _service.GetProductsByName(productName);

            //Same as above
            Helpers.ProductHelperFunctions.FilterPricesByCurrency(results, CurrencyCode.ZAR);

            return results;
        }
    }



    
}