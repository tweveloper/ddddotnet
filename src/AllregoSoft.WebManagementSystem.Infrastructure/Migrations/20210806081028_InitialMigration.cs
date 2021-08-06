using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllregoSoft.WebManagementSystem.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_MemberToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MemberToken", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegMemId = table.Column<long>(type: "bigint", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModMemId = table.Column<int>(type: "int", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SiteMap",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parent = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegMemId = table.Column<long>(type: "bigint", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModMemId = table.Column<int>(type: "int", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SiteMap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Member",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    smsFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maillingFl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseYN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    RegMemId = table.Column<long>(type: "bigint", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModMemId = table.Column<int>(type: "int", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Member_tbl_Role_RoleId",
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
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    C = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    R = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    U = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteMapId = table.Column<int>(type: "int", nullable: false),
                    RegMemId = table.Column<long>(type: "bigint", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModMemId = table.Column<int>(type: "int", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role_Mapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Role_Mapping_tbl_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Member_RoleId",
                table: "tbl_Member",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_Mapping_RoleId",
                table: "tbl_Role_Mapping",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Member");

            migrationBuilder.DropTable(
                name: "tbl_MemberToken");

            migrationBuilder.DropTable(
                name: "tbl_Role_Mapping");

            migrationBuilder.DropTable(
                name: "tbl_SiteMap");

            migrationBuilder.DropTable(
                name: "tbl_Role");
        }
    }
}
