using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsultancyApp
{
    public partial class UserSecurity : DbContext
    {
        public UserSecurity()
            : base("name=UserSecurity")
        {
        }

        public virtual DbSet<UsersSecurity> UsersSecurities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersSecurity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UsersSecurity>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UsersSecurity>()
                .Property(e => e.UserRole)
                .IsUnicode(false);

            modelBuilder.Entity<UsersSecurity>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UsersSecurity>()
                .Property(e => e.Mobile)
                .IsUnicode(false);
        }
    }
}
