using DutyFree.Core.Entities.Products;
using DutyFree.Web.ViewModels.Products;

namespace DutyFree.Web.AppServices.Products
{
    public interface IProductAppService
    {
        IndexViewModel GetViewModel(bool isAdmin);

        IndexViewModel AddProduct(Product product, int userId);

        void DeleteProduct(int productId, int userId);

        Product EditProduct(Product product, int userId);

        Product GetProductData(int productId);

        IndexViewModel SearchProduct(string name, string favorite, int? categoryId = null, int? userId = null);

        void BuyProduct(string name, int userId, decimal price, int productId);
    }
}