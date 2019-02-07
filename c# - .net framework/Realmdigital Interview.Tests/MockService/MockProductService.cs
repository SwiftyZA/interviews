using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Realmdigital_Interview.Tests.MockService
{
    internal class MockProductService : IProductService
    {
        List<Product> _products;

        public MockProductService()
        {
            PopulateMockData();
        }

        private void PopulateMockData()
        {
            using (StreamReader r = new StreamReader("MockData\\many-products.json"))
            {
                string json = r.ReadToEnd();
                _products = JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

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
            return await Task.Run(() => { return _products.FirstOrDefault(x => x.BarCode == barcode); }); 
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await Task.Run(() => { return _products.Where(x => x.ItemName == name).ToList(); });
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
