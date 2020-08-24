using DutyFree.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace DutyFree.Core.Entities.Products
{
    public class Product
    {
        public int ProductID { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool New { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}