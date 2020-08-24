using DutyFree.Core.Constants;
using DutyFree.Core.Entities.Products;
using System.Data.Entity.ModelConfiguration;

namespace DutyFree.Data.EntityFramework.Mappers
{
    internal class CategoryMapper : EntityTypeConfiguration<Category>
    {
        public CategoryMapper()
        {
            ToTable(Tables.Categories, Schemes.Dbo);

            HasKey(k => k.CategoryID);
        }
    }
}