using System.Collections.Generic;
using System.Web.Mvc;
using DutyFree.Core.Enums;
using DutyFree.Web.AppServices.Products;
using DutyFree.Web.Class;
using DutyFree.Web.ViewModels.Products;

namespace DutyFree.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductAppService _productAppService;

        public HomeController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Index()
        {
            var vm = _productAppService.GetViewModel(false);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Search(string name, string favorite, int? categoryId = null)
        {
            var vm = new IndexViewModel();

            if (favorite == FavoriteTag.ByUser.ToString())
            {
                vm = _productAppService.SearchProduct(name, favorite, categoryId, SessionState.CurrentUser.UserID);
            }
            else
            {
                vm = _productAppService.SearchProduct(name, favorite, categoryId);
            }

            return PartialView("_Search", vm);
        }

        [HttpPost]
        public JsonResult AutoComplete(string name, string favorite, int? categoryId = null)
        {
            var vm = new IndexViewModel();

            if (favorite == FavoriteTag.ByUser.ToString())
            {
                vm = _productAppService.SearchProduct(name, favorite, categoryId, SessionState.CurrentUser.UserID);
            }
            else
            {
                vm = _productAppService.SearchProduct(name, favorite, categoryId);
            }

            var names = new List<string>();

            foreach (var item in vm.Products)
            {
                names.Add(item.Name);
            }

            return Json(new { names }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Buy(string name, decimal price, int productId)
        {
            _productAppService.BuyProduct(name, SessionState.CurrentUser.UserID, price, productId);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}