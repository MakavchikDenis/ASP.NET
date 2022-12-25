using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CreateNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ApiBase");

            migrationBuilder.CreateTable(
                name: "Adress",
                schema: "ApiBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aducation",
                schema: "ApiBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCourse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aducation", x => x.Id);
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
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    AducationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Adress_AdressId",
                        column: x => x.AdressId,
                        principalSchema: "ApiBase",
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Aducation_AducationId",
                        column: x => x.AducationId,
                        principalSchema: "ApiBase",
                        principalTable: "Aducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AdressId",
                schema: "ApiBase",
                table: "Persons",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AducationId",
                schema: "ApiBase",
                table: "Persons",
                column: "AducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "ApiBase");

            migrationBuilder.DropTable(
                name: "Adress",
                schema: "ApiBase");

            migrationBuilder.DropTable(
                name: "Aducation",
                schema: "ApiBase");
        }
    }
}
