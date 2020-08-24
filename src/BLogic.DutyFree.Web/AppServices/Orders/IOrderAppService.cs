using DutyFree.Web.ViewModels.Orders;
using System;

namespace DutyFree.Web.AppServices.Orders
{
    public interface IOrderAppService
    {
        IndexViewModel GetOrders(DateTime from, DateTime to, int? userId = null);

        void RemoveOrder(int orderId);

        void UpdateOrder(int orderId, bool isBought, bool isLoss);
    }
}