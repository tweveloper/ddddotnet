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
    class ScmMemberConfiguration : IEntityTypeConfiguration<tbl_ScmMember>
    {
        public void Configure(EntityTypeBuilder<tbl_ScmMember> builder)
        {
            builder.ToTable("tbl_ScmMember");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_ScmMember");

            builder.Property(p => p.Id).HasComment("고유번호");

            builder.Ignore(e => e.DomainEvents);
        }
    }

    //class ScmMemberLogConfiguration : IEntityTypeConfiguration<tbl_ScmMember_Log>
    //{
    //    public void Configure(EntityTypeBuilder<tbl_ScmMember_Log> builder)
    //    {
    //        builder.ToTable("tbl_ScmMember_Log");
    //        builder.HasKey(e => new { e.Id }).HasName("PK_tbl_ScmMember_Log");

    //        builder.Property(p => p.Id).HasComment("고유번호");
            
    //    }
    //}

    class ScmMemberDeliveryConfiguration : IEntityTypeConfiguration<tbl_ScmMember_Delivery>
    {
        public void Configure(EntityTypeBuilder<tbl_ScmMember_Delivery> builder)
        {
            builder.ToTable("tbl_ScmMember_Delivery");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_ScmMember_Delivery");

            builder.Property(p => p.Id).HasComment("고유번호");
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
