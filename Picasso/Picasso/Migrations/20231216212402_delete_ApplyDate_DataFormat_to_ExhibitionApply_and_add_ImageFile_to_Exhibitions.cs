using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picasso.Migrations
{
    /// <inheritdoc />
    public partial class delete_ApplyDate_DataFormat_to_ExhibitionApply_and_add_ImageFile_to_Exhibitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ExhibitionApply",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ExhibitionApply",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
