using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Repositories.Orders;
using System;
using System.Collections.Generic;

namespace DutyFree.Core.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ICollection<Order> GetOrders(DateTime from, DateTime to, int? userId = null)
        {
            var result = _orderRepository.Orders(from, to, userId);

            return result as ICollection<Order>;
        }

        public void RemoveOrder(int orderId)
        {
            _orderRepository.RemoveOrder(orderId);
        }

        public void UpdateOrder(int orderId, bool isBought, bool isLoss)
        {
            _orderRepository.UpdateOrder(orderId, isBought, isLoss);
        }
    }
}