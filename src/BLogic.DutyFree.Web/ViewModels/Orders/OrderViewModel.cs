using DutyFree.Core.Entities.Products;
using DutyFree.Core.Entities.Users;
using System;

namespace DutyFree.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public DateTime DateCreated { get; set; }
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public bool isBought { get; set; }
        public bool IsLoss { get; set; }
        public string FullName => $"{User.FirstName} {User.LastName}";
        public User User { get; set; }
        public Product Product { get; set; }
    }
}