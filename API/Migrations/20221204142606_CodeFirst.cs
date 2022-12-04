using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CodeFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ApiBase");

            migrationBuilder.CreateTable(
                name: "AdressPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKurs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "ApiBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePerson = table.Column<string>(type: "varchar(max)", nullable: false),
                    SurnamePerson = table.Column<string>(type: "varchar(max)", nullable: false),
                    AdressesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_AdressPersons_AdressesId",
                        column: x => x.AdressesId,
                        principalTable: "AdressPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AducationPerson",
                columns: table => new
                {
                    KursesId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AducationPerson", x => new { x.KursesId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_AducationPerson_Aducations_KursesId",
                        column: x => x.KursesId,
                        principalTable: "Aducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AducationPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalSchema: "ApiBase",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AducationPerson_PersonsId",
                table: "AducationPerson",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AdressesId",
                schema: "ApiBase",
                table: "Persons",
                column: "AdressesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AducationPerson");

            migrationBuilder.DropTable(
                name: "Aducations");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "ApiBase");

            migrationBuilder.DropTable(
                name: "AdressPersons");
        }
    }
}
