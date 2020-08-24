using DutyFree.Core.Constants;
using DutyFree.Core.Entities.Products;
using System.Data.Entity.ModelConfiguration;

namespace DutyFree.Data.EntityFramework.Mappers
{
    internal class ProductCategoryMapper : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMapper()
        {
            ToTable(Tables.ProductCategories, Schemes.Dbo);

            HasKey(k => k.ProductCategoryID);

            HasRequired(r => r.Category).WithMany(r => r.ProductCategories).HasForeignKey(r => r.CategoryID);
            HasRequired(r => r.Product).WithMany(r => r.ProductCategories).HasForeignKey(r => r.ProductID);
        }
    }
}