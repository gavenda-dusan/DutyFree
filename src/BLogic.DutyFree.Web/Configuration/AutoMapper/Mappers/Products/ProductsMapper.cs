using AutoMapper;
using DutyFree.Core.Entities.Products;
using DutyFree.Web.ViewModels.Products;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Products
{
    public class ProductsMapper : IProductsMapper
    {
        private readonly IMapper _mapper;

        public ProductsMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ProductViewModel GetProductViewModel(Product entity)
        {
            return _mapper.Map<ProductViewModel>(entity);
        }

        public Product GetProductEntity(ProductViewModel viewModel)
        {
            return _mapper.Map<Product>(viewModel);
        }

        public ICollection<ProductViewModel> GetProductViewModels(ICollection<Product> products)
        {
            return _mapper.Map<ICollection<ProductViewModel>>(products);
        }
    }
}