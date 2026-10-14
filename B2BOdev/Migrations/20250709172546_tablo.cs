using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class tablo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimKod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Durum",
                columns: table => new
                {
                    durumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durum", x => x.durumId);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    FirmaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaUnvanı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Del = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.FirmaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriTip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    MarkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.MarkaID);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    AdresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adres1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilid = table.Column<int>(type: "int", nullable: false),
                    Ilceid = table.Column<int>(type: "int", nullable: false),
                    Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Del = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.AdresID);
                    table.ForeignKey(
                        name: "FK_Adres_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmaID1 = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Firma_FirmaID1",
                        column: x => x.FirmaID1,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmaKategori",
                columns: table => new
                {
                    FirKatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaID = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmaKategori", x => x.FirKatId);
                    table.ForeignKey(
                        name: "FK_FirmaKategori_Firma_FirmaID",
                        column: x => x.FirmaID,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FirmaKategori_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme",
                columns: table => new
                {
                    MalzemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    KAtegoriId = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatVergiOran = table.Column<float>(type: "real", nullable: false),
                    Del = table.Column<int>(type: "int", nullable: false),
                    OzelKod1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OzelKod2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OzelKod3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OzelKod4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OzelKod5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme", x => x.MalzemeId);
                    table.ForeignKey(
                        name: "FK_Malzeme_Birim_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birim",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Malzeme_Kategori_KAtegoriId",
                        column: x => x.KAtegoriId,
                        principalTable: "Kategori",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Malzeme_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "MarkaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    SipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmaId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SipNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurumID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    teslimatadresıd = table.Column<int>(type: "int", nullable: false),
                    AdresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.SipID);
                    table.ForeignKey(
                        name: "FK_Siparis_Adres_AdresID",
                        column: x => x.AdresID,
                        principalTable: "Adres",
                        principalColumn: "AdresID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Siparis_Durum_DurumID",
                        column: x => x.DurumID,
                        principalTable: "Durum",
                        principalColumn: "durumId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Siparis_Firma_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firma",
                        principalColumn: "FirmaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDetay",
                columns: table => new
                {
                    SipDetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SipId = table.Column<int>(type: "int", nullable: false),
                    SiparisSipID = table.Column<int>(type: "int", nullable: false),
                    MalzemeID = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    Miktar = table.Column<float>(type: "real", nullable: false),
                    Fiyat = table.Column<float>(type: "real", nullable: false),
                    Kdv = table.Column<float>(type: "real", nullable: false),
                    IndOran = table.Column<float>(type: "real", nullable: false),
                    IndTutar = table.Column<float>(type: "real", nullable: false),
                    Toplam = table.Column<float>(type: "real", nullable: false),
                    ToplamKdv = table.Column<float>(type: "real", nullable: false),
                    GenelToplam = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDetay", x => x.SipDetID);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Birim_BirimId",
                        column: x => x.BirimId,
                        principalTable: "Birim",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Malzeme_MalzemeID",
                        column: x => x.MalzemeID,
                        principalTable: "Malzeme",
                        principalColumn: "MalzemeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiparisDetay_Siparis_SiparisSipID",
                        column: x => x.SiparisSipID,
                        principalTable: "Siparis",
                        principalColumn: "SipID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_FirmaId",
                table: "Adres",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaKategori_FirmaID",
                table: "FirmaKategori",
                column: "FirmaID");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaKategori_KategoriId",
                table: "FirmaKategori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Malzeme_BirimId",
                table: "Malzeme",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_Malzeme_KAtegoriId",
                table: "Malzeme",
                column: "KAtegoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Malzeme_MarkaId",
                table: "Malzeme",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_AdresID",
                table: "Siparis",
                column: "AdresID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_DurumID",
                table: "Siparis",
                column: "DurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_FirmaId",
                table: "Siparis",
                column: "FirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_BirimId",
                table: "SiparisDetay",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_MalzemeID",
                table: "SiparisDetay",
                column: "MalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisDetay_SiparisSipID",
                table: "SiparisDetay",
                column: "SiparisSipID");

            migrationBuilder.CreateIndex(
                name: "IX_User_FirmaID1",
                table: "User",
                column: "FirmaID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirmaKategori");

            migrationBuilder.DropTable(
                name: "SiparisDetay");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Malzeme");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Durum");

            migrationBuilder.DropTable(
                name: "Firma");
        }
    }
}