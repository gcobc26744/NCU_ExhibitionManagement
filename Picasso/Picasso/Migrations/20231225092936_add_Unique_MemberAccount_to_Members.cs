using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picasso.Migrations
{
    /// <inheritdoc />
    public partial class add_Unique_MemberAccount_to_Members : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Members_MemberAccount",
                table: "Members",
                column: "MemberAccount",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_MemberAccount",
                table: "Members");
        }
    }
}
