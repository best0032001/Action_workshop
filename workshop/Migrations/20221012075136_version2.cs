using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace workshop.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestCol",
                table: "UserEntitys",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCol",
                table: "UserEntitys");
        }
    }
}
