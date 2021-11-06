using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations.ApplicationDB
{
    public partial class LaptopModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Screen",
                table: "Laptops");

            migrationBuilder.AlterColumn<string>(
                name: "Width",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Laptops",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Laptops",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Screen",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
