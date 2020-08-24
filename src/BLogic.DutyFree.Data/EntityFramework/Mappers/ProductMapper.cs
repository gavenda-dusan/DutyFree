using DutyFree.Core.Constants;
using DutyFree.Core.Entities.Products;
using System.Data.Entity.ModelConfiguration;

namespace DutyFree.Data.EntityFramework.Mappers
{
    internal class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            ToTable(Tables.Products, Schemes.Dbo);

            HasKey(k => k.ProductID);

            Ignore(i => i.CategoryID);
            Ignore(i => i.CategoryName);
        }
    }
}