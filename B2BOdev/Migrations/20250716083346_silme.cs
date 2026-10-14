using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class silme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Firma");

            migrationBuilder.DropColumn(
                name: "tel",
                table: "Firma");

            migrationBuilder.AddColumn<int>(
                name: "AdresID",
                table: "Firma",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firma_AdresID",
                table: "Firma",
                column: "AdresID");

            migrationBuilder.AddForeignKey(
                name: "FK_Firma_Adres_AdresID",
                table: "Firma",
                column: "AdresID",
                principalTable: "Adres",
                principalColumn: "AdresID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firma_Adres_AdresID",
                table: "Firma");

            migrationBuilder.DropIndex(
                name: "IX_Firma_AdresID",
                table: "Firma");

            migrationBuilder.DropColumn(
                name: "AdresID",
                table: "Firma");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Firma",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tel",
                table: "Firma",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
