using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2BOdev.Migrations
{
    public partial class iş : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "GorselYolu",
            table: "Malzeme",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: ""); // var olan satırlar için boş string
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "GorselYolu",
            table: "Malzeme");
    }
}
}
