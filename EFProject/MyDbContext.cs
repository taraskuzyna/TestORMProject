using System.Data.Entity;

namespace EFProject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("fb1")
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasOptional(f => f.Address);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
