using System;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using DutyFree.Web.Class;
using DutyFree.Web.AppServices.Products;
using DutyFree.Core.Entities.Products;

namespace DutyFree.Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [SecurityRight("Admin")]
        public ActionResult Index()
        {
            var vm = _productAppService.GetViewModel(true);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(Product product, HttpPostedFileBase picture)
        {
            if (picture != null)
            {
                var image = Image.FromStream(picture.InputStream);
                var guid = Guid.NewGuid();
                var imageName = guid.ToString() + ".png";
                product.ImageUrl = $"/uploads/product/{imageName}";
                image.Save(Server.MapPath($"~/uploads/product/{imageName}"));
            }
            else
            {
                product.ImageUrl = "/site-files/product-placeholder.png";
            }

            if (!product.CategoryID.HasValue)
            {
                product.CategoryName = null;
            }

            var vm = _productAppService.AddProduct(product, SessionState.CurrentUser.UserID);

            return PartialView("_Add", vm);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _productAppService.DeleteProduct(id, SessionState.CurrentUser.UserID);

            return null;
        }

        [HttpPost]
        public JsonResult Edit(Product product, HttpPostedFileBase picture)
        {
            if (picture != null)
            {
                var image = Image.FromStream(picture.InputStream);
                var guid = Guid.NewGuid();
                var imageName = guid.ToString() + ".png";
                product.ImageUrl = $"/uploads/product/{imageName}";
                image.Save(Server.MapPath($"~/uploads/product/{imageName}"));
            }
            else
            {
                product.ImageUrl = "/site-files/product-placeholder.png";
            }

            if (!product.CategoryID.HasValue)
            {
                product.CategoryName = null;
            }

            var p = _productAppService.EditProduct(product, SessionState.CurrentUser.UserID);

            return Json(new
            {
                p.Name,
                p.ImageUrl,
                p.Price,
                p.Quantity,
                p.CategoryName,
                p.New,
                p.PriceAfterDiscount,
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetData(int id)
        {
            var product = _productAppService.GetProductData(id);

            return Json(new
            {
                product.Name,
                product.ImageUrl,
                product.Price,
                product.Quantity,
                product.CategoryName,
                product.New,
                product.PriceAfterDiscount,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}