using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Controllers;
using Realmdigital_Interview.Tests.MockService;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Enums;
using System.Diagnostics;

namespace Realmdigital_Interview.Tests.Controllers
{
    [TestClass]
    public class ProductControllerUnitTests
    {
        ProductController _testController;

        public ProductControllerUnitTests()
        {
            _testController = new ProductController(new MockProductService());
        }

        [TestMethod]
        public async Task GetProductsByName()
        {
            var productName = "item_name_3";

            var products = await _testController.GetProductsByName(productName);

            Assert.IsTrue(products.Count() > 0, "No Products found!");
            Assert.IsNotNull(products.FirstOrDefault(x => x.ItemName == productName), "Incorrect product(s) returned!");

            var s = products.SelectMany(x => x.PriceRecords.Where(y => y.CurrencyCode != CurrencyCode.ZAR));

            Debug.WriteLine(s.Count());

            Assert.IsTrue(
                products.SelectMany(x => x.PriceRecords.Where(y => y.CurrencyCode != CurrencyCode.ZAR)).Count() == 0,
                "Product price filtering failed!");
        }

        [TestMethod]
        public async Task GetProductById()
        {
            var barCode = "bar_code_2";

            var product = await _testController.GetProductById(barCode);

            Assert.IsNotNull(product, "Product is Null!");
            Assert.AreEqual<string>(barCode, product.BarCode, "Incorrect product returned!");
            Assert.IsNull(product.PriceRecords.FirstOrDefault(x => x.CurrencyCode != CurrencyCode.ZAR), "Product price filtering failed!");
        }
    }
}
