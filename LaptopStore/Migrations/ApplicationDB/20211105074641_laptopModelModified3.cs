using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations.ApplicationDB
{
    public partial class laptopModelModified3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemTitle",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemTitle",
                table: "Laptops");
        }
    }
}
