using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Update_Feature_Technology_ProgramingLanguesId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramingTechnologies_ProgramingLangues_ProgramingLanguesId",
                table: "ProgramingTechnologies");

            migrationBuilder.DropColumn(
                name: "ProgLanguageId",
                table: "ProgramingTechnologies");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramingLanguesId",
                table: "ProgramingTechnologies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramingTechnologies_ProgramingLangues_ProgramingLanguesId",
                table: "ProgramingTechnologies",
                column: "ProgramingLanguesId",
                principalTable: "ProgramingLangues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramingTechnologies_ProgramingLangues_ProgramingLanguesId",
                table: "ProgramingTechnologies");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramingLanguesId",
                table: "ProgramingTechnologies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgLanguageId",
                table: "ProgramingTechnologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramingTechnologies_ProgramingLangues_ProgramingLanguesId",
                table: "ProgramingTechnologies",
                column: "ProgramingLanguesId",
                principalTable: "ProgramingLangues",
                principalColumn: "Id");
        }
    }
}
