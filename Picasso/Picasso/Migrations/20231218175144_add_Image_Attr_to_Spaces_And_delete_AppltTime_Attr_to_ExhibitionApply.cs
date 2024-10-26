using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picasso.Migrations
{
    /// <inheritdoc />
    public partial class add_Image_Attr_to_Spaces_And_delete_AppltTime_Attr_to_ExhibitionApply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyTime",
                table: "ExhibitionApply");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Spaces",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Spaces");

            migrationBuilder.AddColumn<bool>(
                name: "ApplyTime",
                table: "ExhibitionApply",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
