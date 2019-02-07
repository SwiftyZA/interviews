using BusinessLayer.Helpers;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessLayer.Managers
{
    public class ProductService : IProductService
    {
        // One can abstract the actual datasource here as well which will allow you to mock at that level and write unit tests for this service class as well.
        // Where the data source would then contain the product CRUD calls to the API. The Product service would then be redundant in its current state, but the
        // functionality prodived could be refactored to be more use-case orientated with business logic being applied like the currency filtering done in the
        // controller. We could potentially include this in a Unit test where Product prices on controller test should only have ZAR prices, but the same test
        // against the ProductService should contain all prices
        /*
        private IDataStore _dataSource;
        public ProductService(IDataStore dataSource)
        {
            _dataSource = dataSource;
        }
        */

        public async Task<string> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProduct(string barcode)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductById(string barcode)
        {
            var json = "{ \"id\": \"" + barcode + "\" }";
            var response = await WebHelpers.ExecuteWebApiCall(json);

            return JsonConvert.DeserializeObject<Product>(response);
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var json = "{ \"names\": \"" + name + "\" }";
            var response = await WebHelpers.ExecuteWebApiCall(json);

            return JsonConvert.DeserializeObject<IEnumerable<Product>>(response);
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
