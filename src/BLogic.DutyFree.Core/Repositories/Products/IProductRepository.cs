using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Entities.Products;
using System.Collections.Generic;

namespace DutyFree.Core.Repositories.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products(bool isAdmin);

        int InsertProduct(Product product);

        void DeleteProduct(int id, int userId);

        void UpdateProduct(Product product);

        IEnumerable<Product> SearchProduct(string name, string favorite, int? categoryId, int? userId = null);

        void BuyProduct(Order order);
    }
}
