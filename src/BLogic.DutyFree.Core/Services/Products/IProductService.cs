using DutyFree.Core.Entities.Products;
using System.Collections.Generic;

namespace DutyFree.Core.Services.Products
{
    public interface IProductService
    {
        ICollection<Product> GetProducts(bool isAdmin);

        Product AddProduct(Product product, int userId);

        void DeleteProduct(int productId, int userId);

        Product EditProduct(Product product, int userId);

        Product GetProductData(int productId);

        ICollection<Product> SearchProduct(string name, string favorite, int? categoryId = null, int? userId = null);

        void BuyProduct(string name, int userId, decimal price, int productId);
    }
}
