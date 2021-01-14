using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DealerMap : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.Name).IsUnique();

            builder.Property(I => I.Address).HasColumnType("ntext").HasMaxLength(200);

            builder.Property(I => I.Email).HasMaxLength(60);

            builder.Property(I => I.PhoneNumber).HasMaxLength(10);


            builder.HasMany(I => I.OrderDetails).WithOne(I => I.Dealer).HasForeignKey(I => I.DealerId);
        }
    }
}
