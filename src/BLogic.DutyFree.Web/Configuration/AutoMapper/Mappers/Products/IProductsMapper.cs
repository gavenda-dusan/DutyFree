using DutyFree.Core.Entities.Products;
using DutyFree.Web.ViewModels.Products;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration.AutoMapper.Mappers.Products
{
    public interface IProductsMapper
    {
        ProductViewModel GetProductViewModel(Product entity);

        Product GetProductEntity(ProductViewModel viewModel);

        ICollection<ProductViewModel> GetProductViewModels(ICollection<Product> products);
    }
}