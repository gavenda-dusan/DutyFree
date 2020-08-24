using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using DutyFree.Web.AppServices.Orders;
using DutyFree.Web.Class;
using DutyFree.Web.ViewModels.Orders;
using SpreadsheetLight;

namespace DutyFree.Web.Controllers
{
    public class ExportController : Controller
    {
        //private readonly CsvGenerator<OrderViewModel> _generator = new CsvGenerator<OrderViewModel>();
        //private readonly IOrderAppService _orderAppService;

        //public ExportController(IOrderAppService orderAppService)
        //{
        //    _orderAppService = orderAppService;
        //}

        //public FileResult ExportToCsv(DateTime from, DateTime to, bool allOrders)
        //{
        //    MapOrdersToCsv(allOrders);
        //    IList<OrderViewModel> orders;

        //    if (!allOrders)
        //    {
        //        var vm = _orderAppService.GetOrders(from, to, SessionState.CurrentUser.UserID);
        //        orders = vm.Orders.ToList();
        //        _generator.FillData(orders);
        //    }
        //    else
        //    {
        //        var vm = _orderAppService.GetOrders(from, to);
        //        orders = vm.Orders.ToList();
        //        _generator.FillData(orders);
        //    }

        //    var bytes = _generator.GenerateBytes(new CsvGenerateBytesConfig { IncludePreamble = true });

        //    return File(new MemoryStream(bytes), "application/csv;charset=utf-8", $"orders_{DateTime.Now.Date:dd_MM_yyyy}.csv");
        //}

        //private void MapOrdersToCsv(bool allOrders)
        //{
        //    if (allOrders)
        //    {
        //        _generator.AddColumn("Uživatel", o => o.FullName);
        //    }
        //    _generator.AddColumn("Datum", o => o.DateCreated.ToString("d", CultureInfo.CreateSpecificCulture("cs-CZ")));
        //    _generator.AddColumn("Čas", o => o.DateCreated.ToString("t", CultureInfo.CreateSpecificCulture("cs-CZ")));
        //    _generator.AddColumn("Produkt", o => o.ProductName);
        //    _generator.AddColumn("Cena", o => o.Price);
        //    _generator.AddColumn("Zakoupeno?", o => o.isBought);
        //    _generator.AddColumn("Ztráta", o => o.IsLoss);
        //}
    }
}