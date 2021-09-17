
using AllregoSoft.WebManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class RoleMappingConfiguration : IEntityTypeConfiguration<tbl_Role_Mapping>
    {
        public void Configure(EntityTypeBuilder<tbl_Role_Mapping> builder)
        {
            builder.ToTable("tbl_Role_Mapping");

            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Role_Mapping");
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
