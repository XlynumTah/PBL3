using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EComWeb.Migrations.ItemDb
{
    public partial class RAM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Products",
                newName: "Storage");

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "Products",
                newName: "Picture");
        }
    }
}
