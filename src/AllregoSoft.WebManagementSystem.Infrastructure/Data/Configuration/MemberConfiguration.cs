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
    class MemberConfiguration : IEntityTypeConfiguration<tbl_Member>
    {
        public void Configure(EntityTypeBuilder<tbl_Member> builder)
        {
            builder.ToTable("tbl_Member");

            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Roles);
            builder.Ignore(e => e.DomainEvents);
        }
    }
}
