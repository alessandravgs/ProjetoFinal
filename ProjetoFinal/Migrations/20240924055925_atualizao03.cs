using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizao03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Descricao",
                table: "Comorbidades");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Comorbidades");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Alergias");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Alergias");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AlergiaPaciente",
                columns: table => new
                {
                    AlergiasId = table.Column<int>(type: "int", nullable: false),
                    PacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlergiaPaciente", x => new { x.AlergiasId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_AlergiaPaciente_Alergias_AlergiasId",
                        column: x => x.AlergiasId,
                        principalTable: "Alergias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlergiaPaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComorbidadePaciente",
                columns: table => new
                {
                    ComorbidadesId = table.Column<int>(type: "int", nullable: false),
                    PacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComorbidadePaciente", x => new { x.ComorbidadesId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_ComorbidadePaciente_Comorbidades_ComorbidadesId",
                        column: x => x.ComorbidadesId,
                        principalTable: "Comorbidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComorbidadePaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlergiaPaciente_PacientesId",
                table: "AlergiaPaciente",
                column: "PacientesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComorbidadePaciente_PacientesId",
                table: "ComorbidadePaciente",
                column: "PacientesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlergiaPaciente");

            migrationBuilder.DropTable(
                name: "ComorbidadePaciente");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pacientes");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Comorbidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Comorbidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Alergias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
