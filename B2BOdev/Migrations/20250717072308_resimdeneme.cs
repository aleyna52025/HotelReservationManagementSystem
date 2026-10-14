using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class resimdeneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "GorselYolu",
                table: "Malzeme",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorselYolu",
                table: "Malzeme");

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
    }
}
