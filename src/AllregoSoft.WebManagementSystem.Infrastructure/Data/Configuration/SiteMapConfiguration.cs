
using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class SiteMapConfiguration : IEntityTypeConfiguration<tbl_SiteMap>
    {
        public void Configure(EntityTypeBuilder<tbl_SiteMap> builder)
        {
            builder.ToTable("tbl_SiteMap");

            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_SiteMap");

            builder.Ignore(e => e.DomainEvents);
        }
    }
}
