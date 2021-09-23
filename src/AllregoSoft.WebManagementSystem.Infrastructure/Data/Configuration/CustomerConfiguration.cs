using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class CustomerConfiguration : IEntityTypeConfiguration<tbl_Customer>
    {
        public void Configure(EntityTypeBuilder<tbl_Customer> builder)
        {
            builder.ToTable("tbl_Customer");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Customer");

            builder.Property(p => p.Id).HasComment("고유번호");

            builder.Ignore(e => e.DomainEvents);
        }
    }

    //class CustomerLogConfiguration : IEntityTypeConfiguration<tbl_Customer_Log>
    //{
    //    public void Configure(EntityTypeBuilder<tbl_Customer_Log> builder)
    //    {
    //        builder.ToTable("tbl_Customer_Log");
    //        builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Customer_Log");

    //        builder.Property(p => p.Id).HasComment("고유번호");
            
    //    }
    //}

    class CustomerDeliveryConfiguration : IEntityTypeConfiguration<tbl_Customer_Delivery>
    {
        public void Configure(EntityTypeBuilder<tbl_Customer_Delivery> builder)
        {
            builder.ToTable("tbl_Customer_Delivery");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Customer_Delivery");

            builder.Property(p => p.Id).HasComment("고유번호");
        }
    }
}
