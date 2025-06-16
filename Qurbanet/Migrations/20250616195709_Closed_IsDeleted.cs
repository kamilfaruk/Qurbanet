using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Qurbanet.Migrations
{
    /// <inheritdoc />
    public partial class Closed_IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "SystemLogs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Sales",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Payments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Organizations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "CuttingEvents",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Customers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Closed",
                table: "Animals",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "SystemLogs",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Sales",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Payments",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Organizations",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CuttingEvents",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Customers",
                newName: "Closed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Animals",
                newName: "Closed");
        }
    }
}
