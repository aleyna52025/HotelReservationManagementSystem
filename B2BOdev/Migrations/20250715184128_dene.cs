using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class dene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Firma_FirmaID1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FirmaID1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FirmaID1",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaID",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_FirmaID",
                table: "User",
                column: "FirmaID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Firma_FirmaID",
                table: "User",
                column: "FirmaID",
                principalTable: "Firma",
                principalColumn: "FirmaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Firma_FirmaID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FirmaID",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "FirmaID",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FirmaID1",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_FirmaID1",
                table: "User",
                column: "FirmaID1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Firma_FirmaID1",
                table: "User",
                column: "FirmaID1",
                principalTable: "Firma",
                principalColumn: "FirmaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
