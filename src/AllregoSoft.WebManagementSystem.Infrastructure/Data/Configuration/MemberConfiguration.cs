using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class MemberConfiguration : IEntityTypeConfiguration<tbl_Member>
    {
        public void Configure(EntityTypeBuilder<tbl_Member> builder)
        {
            builder.ToTable("tbl_Member");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Member");

            builder.Property(p => p.Id).HasComment("고유번호");

            builder.Ignore(e => e.DomainEvents);
        }
    }

    //class MemberLogConfiguration : IEntityTypeConfiguration<tbl_Member_Log>
    //{
    //    public void Configure(EntityTypeBuilder<tbl_Member_Log> builder)
    //    {
    //        builder.ToTable("tbl_Member_Log");
    //        builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Member_Log");

    //        builder.Property(p => p.Id).HasComment("고유번호");
    //    }
    //}
}
