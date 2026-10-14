using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class TeklifSistemi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teklifler",
                columns: table => new
                {
                    TeklifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaID = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teklifler", x => x.TeklifID);
                    table.ForeignKey(
                        name: "FK_Teklifler_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeklifDetaylari",
                columns: table => new
                {
                    TeklifDetayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeklifID = table.Column<int>(type: "int", nullable: false),
                    MalzemeID = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeklifDetaylari", x => x.TeklifDetayID);
                    table.ForeignKey(
                        name: "FK_TeklifDetaylari_Malzeme_MalzemeID",
                        column: x => x.MalzemeID,
                        principalTable: "Malzeme",
                        principalColumn: "MalzemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeklifDetaylari_Teklifler_TeklifID",
                        column: x => x.TeklifID,
                        principalTable: "Teklifler",
                        principalColumn: "TeklifID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeklifDetaylari_MalzemeID",
                table: "TeklifDetaylari",
                column: "MalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_TeklifDetaylari_TeklifID",
                table: "TeklifDetaylari",
                column: "TeklifID");

            migrationBuilder.CreateIndex(
                name: "IX_Teklifler_FirmaID",
                table: "Teklifler",
                column: "FirmaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeklifDetaylari");

            migrationBuilder.DropTable(
                name: "Teklifler");
        }
    }
}
