using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Entities.Products;
using System;
using System.Collections.Generic;

namespace DutyFree.Web.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool New { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}