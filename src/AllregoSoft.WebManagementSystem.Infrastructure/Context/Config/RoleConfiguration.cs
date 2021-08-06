using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Context.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<tbl_Role>
    {
        public void Configure(EntityTypeBuilder<tbl_Role> builder)
        {
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Role");
        }
    }

    public class RoleMappingConfiguration : IEntityTypeConfiguration<tbl_Role_Mapping>
    {
        public void Configure(EntityTypeBuilder<tbl_Role_Mapping> builder)
        {
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Role_Mapping");
            builder.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMapping)
                    .HasForeignKey(d => new { d.RoleId });
        }
    }
}
