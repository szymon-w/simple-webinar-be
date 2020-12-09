using Microsoft.EntityFrameworkCore.Migrations;

namespace simpleWebinar.Migrations
{
    public partial class NameAdjustments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Webinars_WebinarCode",
                table: "Webinars");

            migrationBuilder.DropColumn(
                name: "WebinarCode",
                table: "Webinars");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Webinars",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Webinars_Code",
                table: "Webinars",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Webinars_Code",
                table: "Webinars");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Webinars");

            migrationBuilder.AddColumn<string>(
                name: "WebinarCode",
                table: "Webinars",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Webinars_WebinarCode",
                table: "Webinars",
                column: "WebinarCode",
                unique: true);
        }
    }
}
