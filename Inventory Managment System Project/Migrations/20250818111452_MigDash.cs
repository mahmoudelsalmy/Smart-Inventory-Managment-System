using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System_Project.Migrations
{
    /// <inheritdoc />
    public partial class MigDash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                schema: "ER",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                schema: "ER",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dashboards",
                schema: "ER",
                columns: table => new
                {
                    DashboardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalProducts = table.Column<int>(type: "int", nullable: false),
                    TotalOrders = table.Column<int>(type: "int", nullable: false),
                    TotalRevenue = table.Column<double>(type: "float", nullable: false),
                    LowStockItems = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.DashboardId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DashboardId",
                schema: "ER",
                table: "Products",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DashboardId",
                schema: "ER",
                table: "Orders",
                column: "DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dashboards_DashboardId",
                schema: "ER",
                table: "Orders",
                column: "DashboardId",
                principalSchema: "ER",
                principalTable: "Dashboards",
                principalColumn: "DashboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Dashboards_DashboardId",
                schema: "ER",
                table: "Products",
                column: "DashboardId",
                principalSchema: "ER",
                principalTable: "Dashboards",
                principalColumn: "DashboardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dashboards_DashboardId",
                schema: "ER",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Dashboards_DashboardId",
                schema: "ER",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Dashboards",
                schema: "ER");

            migrationBuilder.DropIndex(
                name: "IX_Products_DashboardId",
                schema: "ER",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DashboardId",
                schema: "ER",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DashboardId",
                schema: "ER",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DashboardId",
                schema: "ER",
                table: "Orders");
        }
    }
}
