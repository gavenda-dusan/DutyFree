using System.Collections.Generic;
using DutyFree.Core.Entities.Products;
using DutyFree.Core.Services.Products;
using DutyFree.Web.Configuration.AutoMapper.Mappers.Products;
using DutyFree.Web.ViewModels.Products;

namespace DutyFree.Web.AppServices.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IProductsMapper _productsMapper;

        public ProductAppService(IProductService productService, IProductsMapper productsMapper)
        {
            _productService = productService;
            _productsMapper = productsMapper;
        }

        public IndexViewModel GetViewModel(bool isAdmin)
        {
            return new IndexViewModel { Products = _productsMapper.GetProductViewModels(_productService.GetProducts(isAdmin)) };
        }

        public IndexViewModel AddProduct(Product product, int userId)
        {
            var list = new List<ProductViewModel> { _productsMapper.GetProductViewModel(_productService.AddProduct(product, userId)) };

            return new IndexViewModel { Products = list };
        }

        public void DeleteProduct(int productId, int userId)
        {
            _productService.DeleteProduct(productId, userId);
        }

        public Product EditProduct(Product product, int userId)
        {
            return _productService.EditProduct(product, userId);
        }

        public Product GetProductData(int productId)
        {
            return _productService.GetProductData(productId);
        }

        public IndexViewModel SearchProduct(string name, string favorite, int? categoryId = null, int? userId = null)
        {
            return new IndexViewModel { Products = _productsMapper.GetProductViewModels(_productService.SearchProduct(name, favorite, categoryId, userId)) };
        }

        public void BuyProduct(string name, int userId, decimal price, int productId)
        {
            _productService.BuyProduct(name, userId, price, productId);
        }
    }
}