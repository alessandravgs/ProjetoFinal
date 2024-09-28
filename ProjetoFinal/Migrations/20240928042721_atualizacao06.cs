using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ImagensCurativos",
                newName: "Id");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "ImagensCurativos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "ImagensCurativos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImagensCurativos",
                newName: "id");
        }
    }
}
