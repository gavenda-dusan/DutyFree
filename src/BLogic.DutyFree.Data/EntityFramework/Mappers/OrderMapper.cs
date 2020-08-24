using DutyFree.Core.Constants;
using DutyFree.Core.Entities.Orders;
using System.Data.Entity.ModelConfiguration;

namespace DutyFree.Data.EntityFramework.Mappers
{
    internal class OrderMapper : EntityTypeConfiguration<Order>
    {
        public OrderMapper()
        {
            ToTable(Tables.Orders, Schemes.Dbo);

            HasKey(k => k.OrderID);

            HasRequired(r => r.Product).WithMany(r => r.Orders).HasForeignKey(r => r.ProductID);
            HasRequired(r => r.User).WithMany(r => r.Orders).HasForeignKey(r => r.UserID);

            Ignore(i => i.FullName);
        }
    }
}