using FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class FactoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-39PR7AQ; Database=FactoryDb;uid=sa;pwd=1234;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new DealerMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
            modelBuilder.ApplyConfiguration(new ProductMap());

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
