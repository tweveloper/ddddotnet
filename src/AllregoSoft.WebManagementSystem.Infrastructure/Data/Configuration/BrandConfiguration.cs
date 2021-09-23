using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class BrandConfiguration : IEntityTypeConfiguration<tbl_Brand>
    {
        public void Configure(EntityTypeBuilder<tbl_Brand> builder)
        {
            builder.ToTable("tbl_Brand");
            builder.HasKey(e => new { e.BrandCd }).HasName("PK_tbl_Brand");

            builder.Ignore(e => e.DomainEvents);
        }
    }

    //class BrandLogConfiguration : IEntityTypeConfiguration<tbl_Brand_Log>
    //{
    //    public void Configure(EntityTypeBuilder<tbl_Brand_Log> builder)
    //    {
    //        builder.ToTable("tbl_Brand_Log");
    //        builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Brand_Log");
    //    }
    //}
}
