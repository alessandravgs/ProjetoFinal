using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvolucaoLesao_CurativoId",
                table: "EvolucaoLesao");

            migrationBuilder.AlterColumn<int>(
                name: "CurativoId",
                table: "EvolucaoLesao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoLesao_CurativoId",
                table: "EvolucaoLesao",
                column: "CurativoId",
                unique: true,
                filter: "[CurativoId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EvolucaoLesao_CurativoId",
                table: "EvolucaoLesao");

            migrationBuilder.AlterColumn<int>(
                name: "CurativoId",
                table: "EvolucaoLesao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvolucaoLesao_CurativoId",
                table: "EvolucaoLesao",
                column: "CurativoId",
                unique: true);
        }
    }
}
