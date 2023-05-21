using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Lab4.Migrations
{
    /// <inheritdoc />
    public partial class secondtry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Hobbies_HobbyId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "HobbyPerson");

            migrationBuilder.DropIndex(
                name: "IX_Links_HobbyId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "HobbyId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Links");

            migrationBuilder.CreateTable(
                name: "HobbiesPersonsLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbiesPersonsLinks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "Title" },
                values: new object[] { 5, "The best of the Christmas, when Santa brings a puzzle", "Puzzle" });

            migrationBuilder.InsertData(
                table: "HobbiesPersonsLinks",
                columns: new[] { "Id", "HobbyId", "LinkId", "PersonID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 2, 3, 1 },
                    { 4, 2, 2, 2 },
                    { 5, 3, 4, 2 },
                    { 6, 1, 5, 3 },
                    { 7, 4, 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbiesPersonsLinks");

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "HobbyId",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "HobbyId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HobbyPerson",
                columns: table => new
                {
                    HobbiesHobbyId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyPerson", x => new { x.HobbiesHobbyId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_HobbyPerson_Hobbies_HobbiesHobbyId",
                        column: x => x.HobbiesHobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 1,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 2,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 3,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 4,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 5,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "LinkId",
                keyValue: 6,
                columns: new[] { "HobbyId", "PersonId" },
                values: new object[] { 4, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Links_HobbyId",
                table: "Links",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyPerson_PersonsPersonId",
                table: "HobbyPerson",
                column: "PersonsPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Hobbies_HobbyId",
                table: "Links",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
