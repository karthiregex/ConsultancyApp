using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataModel
{
    public partial class EfModelLayer : DbContext
    {
        public EfModelLayer()
            : base("name=Model1")
        {
        }

        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeDetail>()
                .Property(e => e.eAddress)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<StudentAddress>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetail>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<StudentDetail>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
