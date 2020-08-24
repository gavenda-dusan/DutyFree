using System.Collections.Generic;
using System.Linq;
using System.Data;
using DutyFree.Core.Entities.Products;
using DutyFree.Core.Repositories.Products;
using DutyFree.Data.Model;
using DutyFree.Data.EntityFramework;
using System;
using DutyFree.Core.Entities.Orders;

namespace DutyFree.Data.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDBConnectionFactory _connectionFactory;
        private readonly DataContext _dataContext;

        public ProductRepository(IDBConnectionFactory connectionFactory, DataContext dataContext)
        {
            _connectionFactory = connectionFactory;
            _dataContext = dataContext;
        }

        public IEnumerable<Product> Products(bool isAdmin)
        {
            if (isAdmin)
            {
                var products = _dataContext
                    .Products
                    .AsNoTracking()
                    .Where(p => !p.IsDeleted)
                    .ToList();

                return products;
            }
            else
            {
                var products = _dataContext
                    .Products
                    .AsNoTracking()
                    .Where(p => p.Quantity > 0 && !p.IsDeleted)
                    .OrderBy(p => p.Name)
                    .ToList();

                return products;
            }
        }

        public int InsertProduct(Product product)
        {
            _dataContext
                .Products
                .Add(product);
            
            _dataContext.SaveChanges();

            return product.ProductID;
        }

        public void DeleteProduct(int id, int userId)
        {
            var product =_dataContext
                .Products
                .Where(p => p.ProductID == id)
                .FirstOrDefault();

            product.IsDeleted = true;
            product.UpdatedBy = userId;
            product.DateUpdated = DateTime.Now;

            _dataContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _dataContext
                .Products
                .Where(p => p.ProductID == product.ProductID)
                .FirstOrDefault();

            prod.DateUpdated = product.DateUpdated;
            prod.UpdatedBy = product.UpdatedBy;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.ImageUrl = product.ImageUrl;
            prod.New = product.New;
            prod.PriceAfterDiscount = product.PriceAfterDiscount;

            _dataContext.SaveChanges();
        }

        public IEnumerable<Product> SearchProduct(string name, string favorite, int? categoryId, int? userId = null)
        {
            var table = _dataContext
                .Orders
                .Where(o => o.UserID == userId || userId == null)
                .GroupBy(o => o.ProductID)
                .Select(s => new { ProductID = s.Key, Count = s.Count() })
                .OrderByDescending(o => o.Count);

            var products = _dataContext
                .Products
                .GroupJoin(_dataContext
                    .ProductCategories,
                        p => p.ProductID,
                        pc => pc.ProductID,
                        (p, pc) => new { Product = p, ProductCategory = pc })
                    .SelectMany(
                        ppc => ppc.ProductCategory.DefaultIfEmpty(),
                        (p, pc) => new { p.Product, ProductCategory = pc })
                    .Select(s => new { s.Product, s.ProductCategory })
                .GroupJoin(table,
                        pr => pr.Product.ProductID,
                        t => t.ProductID,
                        (pr, t) => new { pr.Product, Table = t, pr.ProductCategory.CategoryID })
                    .SelectMany(
                        prt => prt.Table.DefaultIfEmpty(),
                        (pr, t) => new { Product = pr, Table = t })
                    .Select(s => new { s.Product.Product, s.Table.Count, s.Product.CategoryID })
                .Where(p => !p.Product.IsDeleted && p.Product.Quantity > 0 &&
                    ((!categoryId.HasValue || p.CategoryID == categoryId) ||
                    (categoryId == 5 && p.Product.New) ||
                    (categoryId == 6 && p.Product.PriceAfterDiscount.HasValue)) &&
                    (name == null || p.Product.Name.Contains(name)));
            
            if (favorite.Length != 0)
            {
                return products.OrderByDescending(p => p.Count).Select(p => p.Product).ToList();
            }
            else
            {
                return products.OrderBy(p => p.Product.Name).Select(p => p.Product).ToList();
            }
        }

        public void BuyProduct(Order order)
        {
            _dataContext
                .Orders
                .Add(order);

            var product = _dataContext
                .Products
                .Where(p => p.Name == order.ProductName)
                .FirstOrDefault();

            product.Quantity--;

            _dataContext.SaveChanges();
        }
    }
}