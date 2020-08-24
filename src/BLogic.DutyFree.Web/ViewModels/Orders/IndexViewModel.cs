using System;
using System.Collections.Generic;

namespace DutyFree.Web.ViewModels.Orders
{
    public class IndexViewModel
    {
        public ICollection<OrderViewModel> Orders { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}