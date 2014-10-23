namespace Amino.PersonsRepository.Store
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonsRepositoryModel : DbContext
    {
        public PersonsRepositoryModel()
            : base("name=PersonRepositoryModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ZipCode> ZipCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZipCode>()
                .HasMany(e => e.People)
                .WithRequired(e => e.ZipCode)
                .HasForeignKey(e => e.ZipCodeFk)
                .WillCascadeOnDelete(false);
        }
    }
}
