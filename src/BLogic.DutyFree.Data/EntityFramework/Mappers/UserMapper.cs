using DutyFree.Core.Constants;
using DutyFree.Core.Entities.Users;
using System.Data.Entity.ModelConfiguration;

namespace DutyFree.Data.EntityFramework.Mappers
{
    internal class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            ToTable(Tables.Users, Schemes.Dbo);

            HasKey(k => k.UserID);

            Ignore(i => i.FullName);
        }
    }
}