using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curativos_Profissionais_ProfissionalId",
                table: "Curativos");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "Curativos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Curativos_Profissionais_ProfissionalId",
                table: "Curativos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curativos_Profissionais_ProfissionalId",
                table: "Curativos");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "Curativos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Curativos_Profissionais_ProfissionalId",
                table: "Curativos",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }
    }
}
