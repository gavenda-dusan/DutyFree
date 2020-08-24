using DutyFree.Core.Entities.Orders;
using DutyFree.Web.ViewModels.Orders;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Orders
{
    public interface IOrdersMapper
    {
        OrderViewModel GetOrderViewModel(Order entity);

        Order GetOrderEntity(OrderViewModel viewModel);

        ICollection<OrderViewModel> GetOrderViewModels(ICollection<Order> orders);
    }
}