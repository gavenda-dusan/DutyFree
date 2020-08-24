using System.Collections.Generic;

namespace DutyFree.Core.Entities.Products
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}