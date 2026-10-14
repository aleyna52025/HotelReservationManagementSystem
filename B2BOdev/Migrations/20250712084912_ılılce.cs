using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class ılılce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Il",
                columns: table => new
                {
                    Ilid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Il", x => x.Ilid);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    Ilceid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ilid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Ilceid);
                    table.ForeignKey(
                        name: "FK_Ilce_Il_Ilid",
                        column: x => x.Ilid,
                        principalTable: "Il",
                        principalColumn: "Ilid",
                        onDelete: ReferentialAction.Cascade); // Bu cascade olabilir
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_Ilceid",
                table: "Adres",
                column: "Ilceid");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_Ilid",
                table: "Adres",
                column: "Ilid");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_Ilid",
                table: "Ilce",
                column: "Ilid");

            // Burada Cascade yerine Restrict verdik
            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Il_Ilid",
                table: "Adres",
                column: "Ilid",
                principalTable: "Il",
                principalColumn: "Ilid",
                onDelete: ReferentialAction.Restrict);

            // Burada da Cascade yerine Restrict verdik
            migrationBuilder.AddForeignKey(
                name: "FK_Adres_Ilce_Ilceid",
                table: "Adres",
                column: "Ilceid",
                principalTable: "Ilce",
                principalColumn: "Ilceid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Il_Ilid",
                table: "Adres");

            migrationBuilder.DropForeignKey(
                name: "FK_Adres_Ilce_Ilceid",
                table: "Adres");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Il");

            migrationBuilder.DropIndex(
                name: "IX_Adres_Ilceid",
                table: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Adres_Ilid",
                table: "Adres");
        }
    }
}
