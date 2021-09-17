
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
    class Cafe24CodeConfiguration : IEntityTypeConfiguration<r2o_Cafe24_Code>
    {
        public void Configure(EntityTypeBuilder<r2o_Cafe24_Code> builder)
        {
            builder.ToTable("r2o_Cafe24_Code");

            builder.HasKey(e => new { e.CODE_NO }).HasName("PK_r2o_Cafe24_Code");
        }
    }
}
