using Microsoft.EntityFrameworkCore.Migrations;

namespace simpleWebinar.Migrations
{
    public partial class oneParticipationOneNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserWebinar_IdUser",
                table: "UserWebinar");

            migrationBuilder.CreateIndex(
                name: "IX_UserWebinar_IdUser_IdWebinar",
                table: "UserWebinar",
                columns: new[] { "IdUser", "IdWebinar" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserWebinar_IdUser_IdWebinar",
                table: "UserWebinar");

            migrationBuilder.CreateIndex(
                name: "IX_UserWebinar_IdUser",
                table: "UserWebinar",
                column: "IdUser");
        }
    }
}
