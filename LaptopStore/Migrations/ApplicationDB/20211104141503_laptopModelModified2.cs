using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations.ApplicationDB
{
    public partial class laptopModelModified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Laptops");
        }
    }
}
