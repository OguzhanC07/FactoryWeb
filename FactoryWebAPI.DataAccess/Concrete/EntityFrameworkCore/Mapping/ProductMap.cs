using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext").HasMaxLength(300);
            builder.Property(I => I.ImagePath);

            builder.HasMany(I => I.OrderDetails).WithOne(I => I.Product).HasForeignKey(I => I.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
