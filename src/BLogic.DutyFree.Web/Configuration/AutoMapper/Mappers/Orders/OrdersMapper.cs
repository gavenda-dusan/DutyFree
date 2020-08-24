using AutoMapper;
using DutyFree.Core.Entities.Orders;
using DutyFree.Web.ViewModels.Orders;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Orders
{
    public class OrdersMapper : IOrdersMapper
    {
        private readonly IMapper _mapper;

        public OrdersMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderViewModel GetOrderViewModel(Order entity)
        {
            return _mapper.Map<OrderViewModel>(entity);
        }

        public Order GetOrderEntity(OrderViewModel viewModel)
        {
            return _mapper.Map<Order>(viewModel);
        }

        public ICollection<OrderViewModel> GetOrderViewModels(ICollection<Order> orders)
        {
            return _mapper.Map<ICollection<OrderViewModel>>(orders);
        }
    }
}