using AutoMapper;
using DutyFree.Core.Entities.Orders;
using DutyFree.Web.ViewModels.Orders;

namespace DutyFree.Web.Configuration.AutoMapper.Profiles.Orders
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderID, opt => opt.MapFrom(src => src.OrderID)).ReverseMap();
        }
    }
}