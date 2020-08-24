using DutyFree.Core.Entities.Orders;
using DutyFree.Core.Entities.Products;
using DutyFree.Core.Entities.Users;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DutyFree.Data.EntityFramework
{
    public class DataContext : DbContext
    {
        private const string Localhost = "Data Source=DESKTOP-9C7PO60\\MSSQLSERVER01; Initial Catalog=DutyFree; Integrated Security=SSPI";

        public DataContext() : base(Localhost)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            _ = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(typeof(DataContext).Assembly);
        }
    }
}