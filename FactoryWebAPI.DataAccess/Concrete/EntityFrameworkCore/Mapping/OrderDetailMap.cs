using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.NumberOfOrders);


            builder.HasIndex(I => new { I.ProductId, I.DealerId }).IsUnique();
        }
    }
}
