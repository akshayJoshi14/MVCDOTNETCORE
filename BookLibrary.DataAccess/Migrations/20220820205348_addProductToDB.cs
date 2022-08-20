using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary.DataAccess.Migrations
{
    public partial class addProductToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imageurl",
                table: "Products",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "Imageurl");
        }
    }
}
