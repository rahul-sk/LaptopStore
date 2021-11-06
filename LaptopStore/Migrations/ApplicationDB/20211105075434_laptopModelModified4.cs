using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations.ApplicationDB
{
    public partial class laptopModelModified4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Laptops");
        }
    }
}
