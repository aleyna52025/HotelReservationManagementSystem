using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class sond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "TeklifDetaylari",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "GenelToplam",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IndOran",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "IndTutar",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Kdv",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Toplam",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ToplamKdv",
                table: "TeklifDetaylari",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_TeklifDetaylari_BirimId",
                table: "TeklifDetaylari",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeklifDetaylari_Birim_BirimId",
                table: "TeklifDetaylari",
                column: "BirimId",
                principalTable: "Birim",
                principalColumn: "BirimID",
                onDelete: ReferentialAction.Restrict);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeklifDetaylari_Birim_BirimId",
                table: "TeklifDetaylari");

            migrationBuilder.DropIndex(
                name: "IX_TeklifDetaylari_BirimId",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "GenelToplam",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "IndOran",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "IndTutar",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "Kdv",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "Toplam",
                table: "TeklifDetaylari");

            migrationBuilder.DropColumn(
                name: "ToplamKdv",
                table: "TeklifDetaylari");
        }
    }
}
