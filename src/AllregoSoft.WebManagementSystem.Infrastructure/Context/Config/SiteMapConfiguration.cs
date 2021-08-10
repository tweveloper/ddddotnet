using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Context.Config
{
    public class SiteMapConfiguration : IEntityTypeConfiguration<tbl_SiteMap>
    {
        public void Configure(EntityTypeBuilder<tbl_SiteMap> builder)
        {
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_SiteMap");
        }
    }
}
