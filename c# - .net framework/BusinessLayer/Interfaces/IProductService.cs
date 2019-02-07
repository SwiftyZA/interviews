using BusinessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// The assumption is made that the barcode is the unique identifier of the products and that there is some mechanism in place to garantee uniqueness
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Insert Product into data store
        /// </summary>
        /// <param name="product"></param>
        /// <returns>String: Barcode of the inserted item</returns>
        Task<string> CreateProduct(Product product);

        /// <summary>
        /// Selects a Product by barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>Product: The Product with matching barcode</returns>
        Task<IEnumerable<Product>> GetProductsByName(string name);

        /// <summary>
        /// Selects a Product by barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>Product: The Product with matching barcode</returns>
        Task<Product> GetProductById(string barcode);

        /// <summary>
        /// Updates a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>bool: indicates the success status of the update request</returns>
        Task<bool> UpdateProduct(Product product);

        /// <summary>
        /// Deletes a Product with matching barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>bool: indicates the success status of the delete request</returns>
        Task<bool> DeleteProduct(string barcode);
    }
}
