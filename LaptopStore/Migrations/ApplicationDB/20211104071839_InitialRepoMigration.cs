using Microsoft.EntityFrameworkCore.Migrations;

namespace LaptopStore.Migrations.ApplicationDB
{
    public partial class InitialRepoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardDiskSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardDiskType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Display = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Screen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Battery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
