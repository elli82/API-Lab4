using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Lab4.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

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

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Love spending time in the stable, the connection with the horse, riding etc", "Horse-ridng" },
                    { 2, "The mountains, the thrill of the speed, hot chocolate, Jäger etc", "Skiing" },
                    { 3, "Enjoys going out with the boat, hoping to catch a big pike", "Fishing" },
                    { 4, "Enjoys a good match", "Padel" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Elin Otterdahl", 706342635 },
                    { 2, "Marcus Linderholm", 70834728 },
                    { 3, "Sofie Apelqvist", 70726492 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "HobbyId", "PersonId", "WebLink" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://www.varbergsridskola.se" },
                    { 2, 2, 1, "https://www.lofsdalen.com/sv/skidakning" },
                    { 3, 2, 2, "https://www.skistar.com/sv/myskistar/destination/trysil/" },
                    { 4, 3, 2, "https://www.visitvarberg.se/ovrigt/outdoor/outdoorsidor/fiska.html" },
                    { 5, 1, 3, "https://minhast.se/" },
                    { 6, 4, 3, "https://www.facebook.com/ponactive/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbyPerson_PersonsPersonId",
                table: "HobbyPerson",
                column: "PersonsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_HobbyId",
                table: "Links",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyPerson");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
