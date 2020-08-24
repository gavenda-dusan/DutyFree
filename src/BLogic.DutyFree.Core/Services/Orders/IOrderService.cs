using DutyFree.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace DutyFree.Core.Services.Orders
{
    public interface IOrderService
    {
        ICollection<Order> GetOrders(DateTime from, DateTime to, int? userId = null);

        void RemoveOrder(int orderId);

        void UpdateOrder(int orderId, bool isBought, bool isLoss);
    }
}
