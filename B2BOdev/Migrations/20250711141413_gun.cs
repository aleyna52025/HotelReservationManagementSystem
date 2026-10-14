using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class gun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Adres_AdresID",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_AdresID",
                table: "Siparis");

            migrationBuilder.DropColumn(
                name: "AdresID",
                table: "Siparis");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_teslimatadresıd",
                table: "Siparis",
                column: "teslimatadresıd");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Adres_teslimatadresıd",
                table: "Siparis",
                column: "teslimatadresıd",
                principalTable: "Adres",
                principalColumn: "AdresID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Siparis_Adres_teslimatadresıd",
                table: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Siparis_teslimatadresıd",
                table: "Siparis");

            migrationBuilder.AddColumn<int>(
                name: "AdresID",
                table: "Siparis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_AdresID",
                table: "Siparis",
                column: "AdresID");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparis_Adres_AdresID",
                table: "Siparis",
                column: "AdresID",
                principalTable: "Adres",
                principalColumn: "AdresID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
