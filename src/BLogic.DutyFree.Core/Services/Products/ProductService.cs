using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Entities.Products;
using DutyFree.Core.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DutyFree.Core.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<Product> GetProducts(bool isAdmin)
        {
            var result = _productRepository.Products(isAdmin);

            return result as ICollection<Product>;
        }

        public Product AddProduct(Product product, int userId)
        {
            product.CreatedBy = userId;
            product.UpdatedBy = userId;
            product.DateCreated = DateTime.Now;
            product.DateUpdated = DateTime.Now;

            product.ProductID = _productRepository.InsertProduct(product);

            return product;
        }

        public void DeleteProduct(int productId, int userId)
        {
            _productRepository.DeleteProduct(productId, userId);
        }

        public Product EditProduct(Product product, int userId)
        {
            product.UpdatedBy = userId;
            product.DateUpdated = DateTime.Now;

            _productRepository.UpdateProduct(product);

            return product;
        }

        public Product GetProductData(int productId)
        {
            return _productRepository.Products(true).Where(i => i.ProductID == productId).FirstOrDefault();
        }

        public ICollection<Product> SearchProduct(string name, string favorite, int? categoryId = null, int? userId = null)
        {
            var result =  _productRepository.SearchProduct(name, favorite, categoryId, userId);

            return result as ICollection<Product>;
        }

        public void BuyProduct(string name, int userId, decimal price, int productId)
        {
            var order = new Order
            {
                DateCreated = DateTime.Now,
                ProductName = name,
                Price = price,
                UserID = userId,
                ProductID = productId,
                isBought = false,
                IsLoss = false
            };

            _productRepository.BuyProduct(order);
        }
    }
}