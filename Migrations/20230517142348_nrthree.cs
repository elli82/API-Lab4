using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Lab4.Migrations
{
    /// <inheritdoc />
    public partial class nrthree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HobbiesPersonsLinks_HobbyId",
                table: "HobbiesPersonsLinks",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbiesPersonsLinks_PersonID",
                table: "HobbiesPersonsLinks",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbiesPersonsLinks_Hobbies_HobbyId",
                table: "HobbiesPersonsLinks",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HobbiesPersonsLinks_Links_LinkId",
                table: "HobbiesPersonsLinks",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbiesPersonsLinks_Persons_PersonID",
                table: "HobbiesPersonsLinks",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbiesPersonsLinks_Hobbies_HobbyId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbiesPersonsLinks_Links_LinkId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_HobbiesPersonsLinks_Persons_PersonID",
                table: "HobbiesPersonsLinks");

            migrationBuilder.DropIndex(
                name: "IX_HobbiesPersonsLinks_HobbyId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.DropIndex(
                name: "IX_HobbiesPersonsLinks_LinkId",
                table: "HobbiesPersonsLinks");

            migrationBuilder.DropIndex(
                name: "IX_HobbiesPersonsLinks_PersonID",
                table: "HobbiesPersonsLinks");
        }
    }
}
