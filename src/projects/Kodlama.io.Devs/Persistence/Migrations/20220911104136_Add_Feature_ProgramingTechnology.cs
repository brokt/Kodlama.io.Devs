using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Add_Feature_ProgramingTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramingTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProgLanguageId = table.Column<int>(type: "int", nullable: false),
                    ProgramingLanguesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramingTechnologies_ProgramingLangues_ProgramingLanguesId",
                        column: x => x.ProgramingLanguesId,
                        principalTable: "ProgramingLangues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramingTechnologies_ProgramingLanguesId",
                table: "ProgramingTechnologies",
                column: "ProgramingLanguesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingTechnologies");
        }
    }
}
