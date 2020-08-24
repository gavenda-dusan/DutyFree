using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Enums;
using System.Collections.Generic;

namespace DutyFree.Web.ViewModels.Security
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Email { get; set; }
        public string ProfileImgUrl { get; set; }
        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}