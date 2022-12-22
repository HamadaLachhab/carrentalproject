using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXAM_PROJET.Migrations
{
    public partial class addAgence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelID",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "ProprietaireId",
                table: "Voitures");

            migrationBuilder.AddColumn<int>(
                name: "AgenceId",
                table: "Voitures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agences",
                columns: table => new
                {
                    AgenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agences", x => x.AgenceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_AgenceId",
                table: "Voitures",
                column: "AgenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Agences_AgenceId",
                table: "Voitures",
                column: "AgenceId",
                principalTable: "Agences",
                principalColumn: "AgenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Agences_AgenceId",
                table: "Voitures");

            migrationBuilder.DropTable(
                name: "Agences");

            migrationBuilder.DropIndex(
                name: "IX_Voitures_AgenceId",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "AgenceId",
                table: "Voitures");

            migrationBuilder.AddColumn<int>(
                name: "ModelID",
                table: "Voitures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProprietaireId",
                table: "Voitures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
