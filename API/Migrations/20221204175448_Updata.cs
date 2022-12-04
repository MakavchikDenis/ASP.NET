using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Updata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AducationPerson");

            migrationBuilder.AddColumn<int>(
                name: "KursesId",
                schema: "ApiBase",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_KursesId",
                schema: "ApiBase",
                table: "Persons",
                column: "KursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Aducations_KursesId",
                schema: "ApiBase",
                table: "Persons",
                column: "KursesId",
                principalTable: "Aducations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Aducations_KursesId",
                schema: "ApiBase",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_KursesId",
                schema: "ApiBase",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "KursesId",
                schema: "ApiBase",
                table: "Persons");

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
        }
    }
}
