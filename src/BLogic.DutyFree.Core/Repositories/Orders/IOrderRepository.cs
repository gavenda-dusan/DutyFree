using DutyFree.Core.Entities.Orders;
using System;
using System.Collections.Generic;

namespace DutyFree.Core.Repositories.Orders
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders(DateTime from, DateTime to, int? userID = null);

        void RemoveOrder(int orderID);

        void UpdateOrder(int orderId, bool isBought, bool isLoss);
    }
}
