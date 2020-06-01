using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Data.DAL.Migrations
{
    public partial class AddImageToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Courses");
        }
    }
}
