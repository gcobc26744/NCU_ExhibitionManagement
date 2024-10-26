using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picasso.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AdministratorAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdministratorPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AdministratorName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AdministratorPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AdministratorEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionApply",
                columns: table => new
                {
                    ApplyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplyTime = table.Column<bool>(type: "bit", nullable: false),
                    ApplyStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionApply", x => x.ApplyId);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    ExhibitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ExhibitionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExhibitionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CoOrganizer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExhibitionDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExhibitionStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.ExhibitionId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MemberAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MemberIdentity = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MemberPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MemberEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    SpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    SpaceName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpaceLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SpaceCapacity = table.Column<int>(type: "int", nullable: false),
                    SpaceDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SpaceStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.SpaceId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "ExhibitionApply");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Spaces");
        }
    }
}
