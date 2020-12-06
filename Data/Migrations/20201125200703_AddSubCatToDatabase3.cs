using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Data.Migrations
{
    public partial class AddSubCatToDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubCategory");

            migrationBuilder.AddColumn<string>(
                name: "SName",
                table: "SubCategory",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SName",
                table: "SubCategory");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
