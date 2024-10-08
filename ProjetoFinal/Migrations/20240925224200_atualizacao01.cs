﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alergias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coberturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coberturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comorbidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comorbidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Lesoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Membro = table.Column<int>(type: "int", nullable: false),
                    Regiao = table.Column<int>(type: "int", nullable: false),
                    LadoRegiao = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    Cirurgica = table.Column<bool>(type: "bit", nullable: false),
                    Infectada = table.Column<bool>(type: "bit", nullable: false),
                    UlceraVenosa = table.Column<int>(type: "int", nullable: false),
                    DeiscenciaCirurgica = table.Column<bool>(type: "bit", nullable: false),
                    Hanseniase = table.Column<bool>(type: "bit", nullable: false),
                    Miiase = table.Column<bool>(type: "bit", nullable: false),
                    Amputacao = table.Column<bool>(type: "bit", nullable: false),
                    Desbridamento = table.Column<bool>(type: "bit", nullable: false),
                    Traumatica = table.Column<bool>(type: "bit", nullable: false),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimaEvolucaoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesoes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false),
                    LesaoId = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orientacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curativos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curativos_Lesoes_LesaoId",
                        column: x => x.LesaoId,
                        principalTable: "Lesoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curativos_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoberturaCurativo",
                columns: table => new
                {
                    CoberturasId = table.Column<int>(type: "int", nullable: false),
                    CurativosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoberturaCurativo", x => new { x.CoberturasId, x.CurativosId });
                    table.ForeignKey(
                        name: "FK_CoberturaCurativo_Coberturas_CoberturasId",
                        column: x => x.CoberturasId,
                        principalTable: "Coberturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoberturaCurativo_Curativos_CurativosId",
                        column: x => x.CurativosId,
                        principalTable: "Curativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvolucaoLesao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Largura = table.Column<int>(type: "int", nullable: false),
                    Profundidade = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    LesaoId = table.Column<int>(type: "int", nullable: false),
                    CurativoId = table.Column<int>(type: "int", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolucaoLesao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvolucaoLesao_Curativos_CurativoId",
                        column: x => x.CurativoId,
                        principalTable: "Curativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvolucaoLesao_Lesoes_LesaoId",
                        column: x => x.LesaoId,
                        principalTable: "Lesoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EvolucaoLesao_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensCurativos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurativoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensCurativos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagensCurativos_Curativos_CurativoId",
                        column: x => x.CurativoId,
                        principalTable: "Curativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlergiaPaciente_PacientesId",
                table: "AlergiaPaciente",
                column: "PacientesId");

            migrationBuilder.CreateIndex(
                name: "IX_CoberturaCurativo_CurativosId",
                table: "CoberturaCurativo",
                column: "CurativosId");

            migrationBuilder.CreateIndex(
                name: "IX_ComorbidadePaciente_PacientesId",
                table: "ComorbidadePaciente",
                column: "PacientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Curativos_LesaoId",
                table: "Curativos",
                column: "LesaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Curativos_ProfissionalId",
                table: "Curativos",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoLesao_CurativoId",
                table: "EvolucaoLesao",
                column: "CurativoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoLesao_LesaoId",
                table: "EvolucaoLesao",
                column: "LesaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoLesao_ProfissionalId",
                table: "EvolucaoLesao",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensCurativos_CurativoId",
                table: "ImagensCurativos",
                column: "CurativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesoes_PacienteId",
                table: "Lesoes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlergiaPaciente");

            migrationBuilder.DropTable(
                name: "CoberturaCurativo");

            migrationBuilder.DropTable(
                name: "ComorbidadePaciente");

            migrationBuilder.DropTable(
                name: "EvolucaoLesao");

            migrationBuilder.DropTable(
                name: "ImagensCurativos");

            migrationBuilder.DropTable(
                name: "Alergias");

            migrationBuilder.DropTable(
                name: "Coberturas");

            migrationBuilder.DropTable(
                name: "Comorbidades");

            migrationBuilder.DropTable(
                name: "Curativos");

            migrationBuilder.DropTable(
                name: "Lesoes");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
