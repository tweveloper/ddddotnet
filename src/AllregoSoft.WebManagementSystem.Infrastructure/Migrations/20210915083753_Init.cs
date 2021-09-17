using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "r2o_Cafe24_Code",
                columns: table => new
                {
                    CODE_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    STATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MALL_ID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_r2o_Cafe24_Code", x => x.CODE_NO);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Adjust_Master",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scm_Id = table.Column<long>(type: "bigint", nullable: false),
                    BrandCd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdjustSendDt = table.Column<int>(type: "int", nullable: false),
                    BrandAgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Adjust_Master", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Adjust_Master_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AM_Id = table.Column<long>(type: "bigint", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<long>(type: "bigint", nullable: false),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Adjust_Master_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Brand",
                columns: table => new
                {
                    BrandCd = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDisp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupId = table.Column<long>(type: "bigint", nullable: false),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Brand", x => x.BrandCd);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Brand_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandCd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<long>(type: "bigint", nullable: false),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Brand_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomPw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M_Id = table.Column<long>(type: "bigint", nullable: true),
                    UseYn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Customer_Delivery",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressJi1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressJi2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seq = table.Column<int>(type: "int", nullable: true),
                    C_Id = table.Column<long>(type: "bigint", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCheck = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Customer_Delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Customer_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Id = table.Column<long>(type: "bigint", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<long>(type: "bigint", nullable: false),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Customer_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Influencer_Master",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfluencerNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfluencerLv = table.Column<int>(type: "int", nullable: false),
                    MallNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depositor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseYn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowCnt = table.Column<int>(type: "int", nullable: false),
                    NeighborCnt = table.Column<int>(type: "int", nullable: true),
                    SubscriberCnt = table.Column<int>(type: "int", nullable: true),
                    CafeMemberCnt = table.Column<int>(type: "int", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: true),
                    CommenderId = table.Column<long>(type: "bigint", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Influencer_Master", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Influencer_Master_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfIId = table.Column<long>(type: "bigint", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Influencer_Master_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Member_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemId = table.Column<long>(type: "bigint", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<long>(type: "bigint", nullable: false),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Member_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ScmMember_Delivery",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryType = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressJi1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressJi2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ScmMember_Delivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ScmMember_Log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scm_Id = table.Column<long>(type: "bigint", nullable: false),
                    Msg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModId = table.Column<long>(type: "bigint", nullable: false),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ScmMember_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SiteMap",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<long>(type: "bigint", nullable: true),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SiteMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Member",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    InfId = table.Column<long>(type: "bigint", nullable: true),
                    Hphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depositor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseYn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrdBaseDate = table.Column<int>(type: "int", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderSaveDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IniShopId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Member_tbl_Influencer_Master_InfId",
                        column: x => x.InfId,
                        principalTable: "tbl_Influencer_Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Member_tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ScmMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "고유번호")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScmId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    RPId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseYn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyId = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: true),
                    IdentityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ScmMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ScmMember_tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role_Mapping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteMapId = table.Column<long>(type: "bigint", nullable: false),
                    RegId = table.Column<long>(type: "bigint", nullable: false),
                    RegDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModId = table.Column<long>(type: "bigint", nullable: true),
                    ModDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Role_Mapping_tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Role_Mapping_tbl_SiteMap_SiteMapId",
                        column: x => x.SiteMapId,
                        principalTable: "tbl_SiteMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Member_InfId",
                table: "tbl_Member",
                column: "InfId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Member_RoleId",
                table: "tbl_Member",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_Mapping_RoleId",
                table: "tbl_Role_Mapping",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_Mapping_SiteMapId",
                table: "tbl_Role_Mapping",
                column: "SiteMapId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ScmMember_RoleId",
                table: "tbl_ScmMember",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "r2o_Cafe24_Code");

            migrationBuilder.DropTable(
                name: "tbl_Adjust_Master");

            migrationBuilder.DropTable(
                name: "tbl_Adjust_Master_Log");

            migrationBuilder.DropTable(
                name: "tbl_Brand");

            migrationBuilder.DropTable(
                name: "tbl_Brand_Log");

            migrationBuilder.DropTable(
                name: "tbl_Customer");

            migrationBuilder.DropTable(
                name: "tbl_Customer_Delivery");

            migrationBuilder.DropTable(
                name: "tbl_Customer_Log");

            migrationBuilder.DropTable(
                name: "tbl_Influencer_Master_Log");

            migrationBuilder.DropTable(
                name: "tbl_Member");

            migrationBuilder.DropTable(
                name: "tbl_Member_Log");

            migrationBuilder.DropTable(
                name: "tbl_Role_Mapping");

            migrationBuilder.DropTable(
                name: "tbl_ScmMember");

            migrationBuilder.DropTable(
                name: "tbl_ScmMember_Delivery");

            migrationBuilder.DropTable(
                name: "tbl_ScmMember_Log");

            migrationBuilder.DropTable(
                name: "tbl_Influencer_Master");

            migrationBuilder.DropTable(
                name: "tbl_SiteMap");

            migrationBuilder.DropTable(
                name: "tbl_Role");
        }
    }
}
