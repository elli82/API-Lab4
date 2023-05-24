using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Lab4.Migrations
{
    /// <inheritdoc />
    public partial class Linc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.CreateIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks",
                column: "LinkId",
                unique: true,
                filter: "[LinkId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.CreateIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks",
                column: "LinkId");
        }
    }
}
