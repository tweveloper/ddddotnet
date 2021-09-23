using AllregoSoft.WebManagementSystem.Domain.Entities;
using AllregoSoft.WebManagementSystem.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Data.Configuration
{
    class InfluencerConfiguration : IEntityTypeConfiguration<tbl_Influencer_Master>
    {
        public void Configure(EntityTypeBuilder<tbl_Influencer_Master> builder)
        {
            builder.ToTable("tbl_Influencer_Master");
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Influencer_Master");

            builder.Property(p => p.Id).HasComment("고유번호");

            builder.Ignore(e => e.DomainEvents);
        }
    }

    //class InfluencerLogConfiguration : IEntityTypeConfiguration<tbl_Influencer_Master_Log>
    //{
    //    public void Configure(EntityTypeBuilder<tbl_Influencer_Master_Log> builder)
    //    {
    //        builder.ToTable("tbl_Influencer_Master_Log");
    //        builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Influencer_Master_Log");

    //        builder.Property(p => p.Id).HasComment("고유번호");
    //    }
    //}
}
