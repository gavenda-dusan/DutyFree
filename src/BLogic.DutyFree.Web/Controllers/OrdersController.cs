using System;
using System.Web.Mvc;
using DutyFree.Web.AppServices.Orders;
using DutyFree.Web.Class;
using DutyFree.Web.ViewModels.Orders;

namespace DutyFree.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderAppService _orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public ActionResult ByUser()
        {
            var from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var to = DateTime.Now;

            var vm = _orderAppService.GetOrders(from, to, SessionState.CurrentUser.UserID);

            return View(vm);
        }

        [SecurityRight("Admin")]
        public ActionResult All()
        {
            var from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var to = DateTime.Now;

            var vm = _orderAppService.GetOrders(from, to);

            return View("ByUser", vm);
        }

        [HttpPost]
        public ActionResult RemoveOrder(int orderID)
        {
            _orderAppService.RemoveOrder(orderID);

            return null;
        }

        [SecurityRight("Admin")]
        [HttpPost]
        public ActionResult FilterAll(DateTime from, DateTime to, bool allOrders)
        {
            return PartialView("_FilterOrders", FilterOrders(from, to, allOrders));
        }

        [HttpPost]
        public ActionResult FilterByUser(DateTime from, DateTime to, bool allOrders)
        {
            return PartialView("_FilterOrders", FilterOrders(from, to, allOrders));
        }

        [HttpPost]
        public void UpdateOrder(int orderId, bool isBought, bool isLoss)
        {
            _orderAppService.UpdateOrder(orderId, isBought, isLoss);
        }

        private IndexViewModel FilterOrders(DateTime from, DateTime to, bool allOrders)
        {
            if (to.Month == 12 && to.Day == 31)
            {
                to = to.AddYears(1);
                to = new DateTime(to.Year, 1, 1);
            }
            else if (DateTime.DaysInMonth(to.Year, to.Month) != to.Day)
            {
                to = to.AddDays(1);
            }
            else
            {
                to = to.AddMonths(1);
                to = new DateTime(to.Year, to.Month, 1);
            }

            var vm = new IndexViewModel();

            if (!allOrders)
            {
                vm = _orderAppService.GetOrders(from, to, SessionState.CurrentUser.UserID);
            }
            else
            {
                vm = _orderAppService.GetOrders(from, to);
            }

            return vm;
        }
    }
}