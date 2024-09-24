using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizao02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Comorbidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Alergias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comorbidades_PacienteId",
                table: "Comorbidades",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_PacienteId",
                table: "Alergias",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alergias_Pacientes_PacienteId",
                table: "Alergias",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comorbidades_Pacientes_PacienteId",
                table: "Comorbidades",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alergias_Pacientes_PacienteId",
                table: "Alergias");

            migrationBuilder.DropForeignKey(
                name: "FK_Comorbidades_Pacientes_PacienteId",
                table: "Comorbidades");

            migrationBuilder.DropIndex(
                name: "IX_Comorbidades_PacienteId",
                table: "Comorbidades");

            migrationBuilder.DropIndex(
                name: "IX_Alergias_PacienteId",
                table: "Alergias");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Comorbidades");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Alergias");
        }
    }
}
