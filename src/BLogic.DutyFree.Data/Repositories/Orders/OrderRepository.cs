using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Repositories.Orders;
using DutyFree.Data.EntityFramework;
using DutyFree.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DutyFree.Data.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDBConnectionFactory _connectionFactory;
        private readonly DataContext _dataContext;

        public OrderRepository(IDBConnectionFactory connectionFactory, DataContext dataContext)
        {
            _connectionFactory = connectionFactory;
            _dataContext = dataContext;
        }

        public IEnumerable<Order> Orders(DateTime from, DateTime to, int? userID = null)
        {
            var orders = _dataContext
                .Orders
                .Include(o => o.User)
                .AsNoTracking()
                .Where(o => o.DateCreated >= from && o.DateCreated <= to && (userID == null || o.UserID == userID))
                .ToList();

            return orders;
        }

        public void RemoveOrder(int orderID)
        {
            _dataContext
                .Orders
                .Remove(_dataContext
                    .Orders
                    .Where(o => o.OrderID == orderID)
                    .FirstOrDefault()
                );

            _dataContext.SaveChanges();
        }

        public void UpdateOrder(int orderId, bool isBought, bool isLoss)
        {
            var order = _dataContext
                .Orders
                .Where(o => o.OrderID == orderId)
                .FirstOrDefault();

            order.isBought = isBought;
            order.IsLoss = isLoss;

            _dataContext.SaveChanges();
        }
    }
}
