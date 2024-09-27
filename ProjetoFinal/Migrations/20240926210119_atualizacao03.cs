﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvolucaoLesao_Profissionais_ProfissionalId",
                table: "EvolucaoLesao");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "EvolucaoLesao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EvolucaoLesao_Profissionais_ProfissionalId",
                table: "EvolucaoLesao",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvolucaoLesao_Profissionais_ProfissionalId",
                table: "EvolucaoLesao");

            migrationBuilder.AlterColumn<int>(
                name: "ProfissionalId",
                table: "EvolucaoLesao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EvolucaoLesao_Profissionais_ProfissionalId",
                table: "EvolucaoLesao",
                column: "ProfissionalId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
