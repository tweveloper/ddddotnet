﻿// <auto-generated />
using System;
using AllregoSoft.WebManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AwmsDbContext))]
    [Migration("20210915083753_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Adjust_Master", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdjustCheck")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdjustSendDt")
                        .HasColumnType("int");

                    b.Property<string>("AdjustStandard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandAgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandCd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<long>("Scm_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Adjust_Master");

                    b.ToTable("tbl_Adjust_Master");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Brand", b =>
                {
                    b.Property<string>("BrandCd")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandNm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<long>("SupId")
                        .HasColumnType("bigint");

                    b.Property<string>("isDisp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandCd")
                        .HasName("PK_tbl_Brand");

                    b.ToTable("tbl_Brand");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomPw")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeyId")
                        .HasColumnType("int");

                    b.Property<long?>("M_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<string>("UseYn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Customer");

                    b.ToTable("tbl_Customer");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Customer_Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressJi1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressJi2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("C_Id")
                        .HasColumnType("bigint");

                    b.Property<bool?>("IsCheck")
                        .HasColumnType("bit");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Seq")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Customer_Delivery");

                    b.ToTable("tbl_Customer_Delivery");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Influencer_Master", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Birth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CafeMemberCnt")
                        .HasColumnType("int");

                    b.Property<long?>("CommenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Depositor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FollowCnt")
                        .HasColumnType("int");

                    b.Property<string>("Hp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InStarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InfluencerLv")
                        .HasColumnType("int");

                    b.Property<string>("InfluencerNm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KeyId")
                        .HasColumnType("int");

                    b.Property<string>("MallNm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<int?>("NeighborCnt")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<int?>("SubscriberCnt")
                        .HasColumnType("int");

                    b.Property<string>("UseYn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YoutubeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Influencer_Master");

                    b.ToTable("tbl_Influencer_Master");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankNm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Depositor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("End_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Hphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("InfId")
                        .HasColumnType("bigint");

                    b.Property<string>("IniShopId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("OrderSaveDt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PrdBaseDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("ShopName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShopUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseYn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Member");

                    b.HasIndex("InfId");

                    b.HasIndex("RoleId");

                    b.ToTable("tbl_Member");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Role");

                    b.ToTable("tbl_Role");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role_Mapping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Auth1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Auth2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("D")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("R")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<long>("SiteMapId")
                        .HasColumnType("bigint");

                    b.Property<string>("U")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Role_Mapping");

                    b.HasIndex("RoleId");

                    b.HasIndex("SiteMapId");

                    b.ToTable("tbl_Role_Mapping");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_ScmMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Hphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KeyId")
                        .HasColumnType("int");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Point")
                        .HasColumnType("int");

                    b.Property<long?>("RPId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("ScmId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseYn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_ScmMember");

                    b.HasIndex("RoleId");

                    b.ToTable("tbl_ScmMember");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_ScmMember_Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressJi1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressJi2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("DeliveryType")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<long>("SMId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_tbl_ScmMember_Delivery");

                    b.ToTable("tbl_ScmMember_Delivery");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_SiteMap", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Parent")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("RegId")
                        .HasColumnType("bigint");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_SiteMap");

                    b.ToTable("tbl_SiteMap");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.r2o_Cafe24_Code", b =>
                {
                    b.Property<int>("CODE_NO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CODE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MALL_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STATE")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CODE_NO")
                        .HasName("PK_r2o_Cafe24_Code");

                    b.ToTable("r2o_Cafe24_Code");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_Adjust_Master_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AM_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Adjust_Master_Log");

                    b.ToTable("tbl_Adjust_Master_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_Brand_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandCd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Brand_Log");

                    b.ToTable("tbl_Brand_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_Customer_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("C_Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Customer_Log");

                    b.ToTable("tbl_Customer_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_Influencer_Master_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("InfIId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Influencer_Master_Log");

                    b.ToTable("tbl_Influencer_Master_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_Member_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_tbl_Member_Log");

                    b.ToTable("tbl_Member_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.ValueObjects.tbl_ScmMember_Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasComment("고유번호")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModDt")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModId")
                        .HasColumnType("bigint");

                    b.Property<string>("Msg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Scm_Id")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK_tbl_ScmMember_Log");

                    b.ToTable("tbl_ScmMember_Log");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Member", b =>
                {
                    b.HasOne("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Influencer_Master", "Influencer")
                        .WithMany()
                        .HasForeignKey("InfId");

                    b.HasOne("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Influencer");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role_Mapping", b =>
                {
                    b.HasOne("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_SiteMap", "SiteMap")
                        .WithMany()
                        .HasForeignKey("SiteMapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("SiteMap");
                });

            modelBuilder.Entity("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_ScmMember", b =>
                {
                    b.HasOne("AllregoSoft.WebManagementSystem.Domain.Entities.tbl_Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
