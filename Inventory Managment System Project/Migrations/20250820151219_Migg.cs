using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System_Project.Migrations
{
    /// <inheritdoc />
    public partial class Migg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ER",
                table: "Warehouses",
                newName: "WarehouseName");

            migrationBuilder.RenameColumn(
                name: "Manager",
                schema: "ER",
                table: "Warehouses",
                newName: "ManagerName");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                schema: "ER",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "ER",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                schema: "ER",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "ER",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "WarehouseName",
                schema: "ER",
                table: "Warehouses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ManagerName",
                schema: "ER",
                table: "Warehouses",
                newName: "Manager");
        }
    }
}
