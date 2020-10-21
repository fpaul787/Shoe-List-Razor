using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoeListRazor.Migrations
{
    public partial class ADDISBNToShoeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Shoe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Shoe");
        }
    }
}
