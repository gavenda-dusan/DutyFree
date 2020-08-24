using DutyFree.Core.Services.Orders;
using DutyFree.Web.Configuration.AutoMapper.Mappers.Orders;
using DutyFree.Web.ViewModels.Orders;
using System;

namespace DutyFree.Web.AppServices.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IOrdersMapper _orderMapper;

        public OrderAppService(IOrderService orderService, IOrdersMapper orderMapper)
        {
            _orderService = orderService;
            _orderMapper = orderMapper;
        }

        public IndexViewModel GetOrders(DateTime from, DateTime to, int? userId = null)
        {
            var list = _orderMapper.GetOrderViewModels(_orderService.GetOrders(from, to, userId));

            return new IndexViewModel { Orders = list, From = from, To = to };
        }

        public void RemoveOrder(int orderId)
        {
            _orderService.RemoveOrder(orderId);
        }

        public void UpdateOrder(int orderId, bool isBought, bool isLoss)
        {
            _orderService.UpdateOrder(orderId, isBought, isLoss);
        }
    }
}