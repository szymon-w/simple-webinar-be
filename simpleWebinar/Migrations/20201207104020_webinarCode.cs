using Microsoft.EntityFrameworkCore.Migrations;

namespace simpleWebinar.Migrations
{
    public partial class webinarCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebinarCode",
                table: "Webinar",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Webinar_WebinarCode",
                table: "Webinar",
                column: "WebinarCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Webinar_WebinarCode",
                table: "Webinar");

            migrationBuilder.DropColumn(
                name: "WebinarCode",
                table: "Webinar");
        }
    }
}
