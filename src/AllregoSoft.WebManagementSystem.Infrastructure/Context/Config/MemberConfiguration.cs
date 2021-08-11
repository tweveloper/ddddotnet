using AllregoSoft.WebManagementSystem.ApplicationCore.Entities;
using AllregoSoft.WebManagementSystem.Infrastructure.Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Reflection;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Context.Config
{
    public class MemberConfiguration : IEntityTypeConfiguration<tbl_Member>
    {
        public void Configure(EntityTypeBuilder<tbl_Member> builder)
        {
            builder.HasKey(e => new { e.Id }).HasName("PK_tbl_Member");

            //foreach(var property in typeof(tbl_Member).GetProperties())
            //{
            //    var attrs = property.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //    var description = ((DescriptionAttribute)attrs[0]).Description;
            //    builder.Property<tbl_Member>(property.Name).HasComment(description);
            //}

            builder.Property(p => p.Id).HasComment("고유번호");
            builder.Property(p => p.Name).HasComment("이름");

            builder.HasOne(d => d.Role).WithMany(e => e.Member).HasForeignKey(d => d.RoleId);

            //DescriptionManager<tbl_Member>.UpdateHasComment(builder);
        }
    }

    public class MemberTokenConfiguration : IEntityTypeConfiguration<tbl_MemberToken>
    {
        public void Configure(EntityTypeBuilder<tbl_MemberToken> builder)
        {
            builder.HasKey(e => new { e.Token }).HasName("PK_tbl_MemberToken");
        }
    }
}
