using AutoMapper;
using DutyFree.Core.Entities.Products;
using DutyFree.Web.ViewModels.Products;

namespace DutyFree.Web.Configuration.AutoMapper.Profiles.Products
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductID)).ReverseMap();
        }
    }
}