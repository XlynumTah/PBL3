using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECom.DataAccess.Migrations
{
    public partial class editItemOrdered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrdered_PictureUri",
                table: "OrderItems",
                newName: "ItemOrdered_ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemOrdered_ImageUrl",
                table: "OrderItems",
                newName: "ItemOrdered_PictureUri");
        }
    }
}
