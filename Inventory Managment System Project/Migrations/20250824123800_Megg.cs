using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System_Project.Migrations
{
    /// <inheritdoc />
    public partial class Megg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "ER",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalShipments",
                schema: "ER",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "TotalOrders",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "ER",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalRevenue",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                schema: "ER",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "TotalAmount",
                schema: "ER",
                table: "OrderItems",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "ER",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                schema: "ER",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                schema: "ER",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "TotalOrders",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "ER",
                table: "Reports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalShipments",
                schema: "ER",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                schema: "ER",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
