using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class AddSelfReferenceToKategori : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UstKategoriId",
                table: "Kategori",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategori_UstKategoriId",
                table: "Kategori",
                column: "UstKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategori_Kategori_UstKategoriId",
                table: "Kategori",
                column: "UstKategoriId",
                principalTable: "Kategori",
                principalColumn: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategori_Kategori_UstKategoriId",
                table: "Kategori");

            migrationBuilder.DropIndex(
                name: "IX_Kategori_UstKategoriId",
                table: "Kategori");

            migrationBuilder.DropColumn(
                name: "UstKategoriId",
                table: "Kategori");
        }
    }
}
