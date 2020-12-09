using Microsoft.EntityFrameworkCore.Migrations;

namespace simpleWebinar.Migrations
{
    public partial class NameAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Webinar",
                table: "Webinar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWebinar",
                table: "UserWebinar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Webinar",
                newName: "Webinars");

            migrationBuilder.RenameTable(
                name: "UserWebinar",
                newName: "UserWebinars");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_Webinar_WebinarCode",
                table: "Webinars",
                newName: "IX_Webinars_WebinarCode");

            migrationBuilder.RenameIndex(
                name: "IX_Webinar_IdUser",
                table: "Webinars",
                newName: "IX_Webinars_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserWebinar_IdUser_IdWebinar",
                table: "UserWebinars",
                newName: "IX_UserWebinars_IdUser_IdWebinar");

            migrationBuilder.RenameIndex(
                name: "IX_UserWebinar_IdWebinar",
                table: "UserWebinars",
                newName: "IX_UserWebinars_IdWebinar");

            migrationBuilder.RenameIndex(
                name: "IX_User_Login",
                table: "Users",
                newName: "IX_Users_Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Webinars",
                table: "Webinars",
                column: "IdWebinar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWebinars",
                table: "UserWebinars",
                column: "IdUserWebinar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebinars_Users_IdUser",
                table: "UserWebinars",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWebinars_Webinars_IdWebinar",
                table: "UserWebinars",
                column: "IdWebinar",
                principalTable: "Webinars",
                principalColumn: "IdWebinar",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Webinars_Users_IdUser",
                table: "Webinars",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWebinars_Users_IdUser",
                table: "UserWebinars");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWebinars_Webinars_IdWebinar",
                table: "UserWebinars");

            migrationBuilder.DropForeignKey(
                name: "FK_Webinars_Users_IdUser",
                table: "Webinars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Webinars",
                table: "Webinars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWebinars",
                table: "UserWebinars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Webinars",
                newName: "Webinar");

            migrationBuilder.RenameTable(
                name: "UserWebinars",
                newName: "UserWebinar");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Webinars_WebinarCode",
                table: "Webinar",
                newName: "IX_Webinar_WebinarCode");

            migrationBuilder.RenameIndex(
                name: "IX_Webinars_IdUser",
                table: "Webinar",
                newName: "IX_Webinar_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserWebinars_IdUser_IdWebinar",
                table: "UserWebinar",
                newName: "IX_UserWebinar_IdUser_IdWebinar");

            migrationBuilder.RenameIndex(
                name: "IX_UserWebinars_IdWebinar",
                table: "UserWebinar",
                newName: "IX_UserWebinar_IdWebinar");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Login",
                table: "User",
                newName: "IX_User_Login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Webinar",
                table: "Webinar",
                column: "IdWebinar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWebinar",
                table: "UserWebinar",
                column: "IdUserWebinar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "IdUser");

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
    }
}
