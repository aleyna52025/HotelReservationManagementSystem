using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class sil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firma_Adres_AdresID",
                table: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_Firma_AdresID",
                table: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres");

            migrationBuilder.DropColumn(
                name: "AdresID",
                table: "Firma");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres",
                column: "FirmaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres");

            migrationBuilder.AddColumn<int>(
                name: "AdresID",
                table: "Firma",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firma_AdresID",
                table: "Firma",
                column: "AdresID");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firma_Adres_AdresID",
                table: "Firma",
                column: "AdresID",
                principalTable: "Adres",
                principalColumn: "AdresID");
        }
    }
}
