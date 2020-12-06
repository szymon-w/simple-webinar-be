using Microsoft.EntityFrameworkCore.Migrations;

namespace simpleWebinar.Migrations
{
    public partial class references : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Webinar",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "UserWebinar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdWebinar",
                table: "UserWebinar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Webinar_IdUser",
                table: "Webinar",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserWebinar_IdUser",
                table: "UserWebinar",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserWebinar_IdWebinar",
                table: "UserWebinar",
                column: "IdWebinar");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebinar_User_IdUser",
                table: "UserWebinar",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebinar_Webinar_IdWebinar",
                table: "UserWebinar",
                column: "IdWebinar",
                principalTable: "Webinar",
                principalColumn: "IdWebinar",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Webinar_User_IdUser",
                table: "Webinar",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWebinar_User_IdUser",
                table: "UserWebinar");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebinar_Webinar_IdWebinar",
                table: "UserWebinar");

            migrationBuilder.DropForeignKey(
                name: "FK_Webinar_User_IdUser",
                table: "Webinar");

            migrationBuilder.DropIndex(
                name: "IX_Webinar_IdUser",
                table: "Webinar");

            migrationBuilder.DropIndex(
                name: "IX_UserWebinar_IdUser",
                table: "UserWebinar");

            migrationBuilder.DropIndex(
                name: "IX_UserWebinar_IdWebinar",
                table: "UserWebinar");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Webinar");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "UserWebinar");

            migrationBuilder.DropColumn(
                name: "IdWebinar",
                table: "UserWebinar");
        }
    }
}
