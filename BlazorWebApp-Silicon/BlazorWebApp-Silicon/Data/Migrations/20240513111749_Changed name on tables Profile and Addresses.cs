using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApp_Silicon.Migrations
{
    /// <inheritdoc />
    public partial class ChangednameontablesProfileandAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAddresses_ApplicationUserAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfiles_ApplicationUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "AspNetUserProfiles");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                newName: "AspNetUserAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserProfiles",
                table: "AspNetUserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserAddresses",
                table: "AspNetUserAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUserAddresses_ApplicationUserAddressId",
                table: "AspNetUsers",
                column: "ApplicationUserAddressId",
                principalTable: "AspNetUserAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUserProfiles_ApplicationUserProfileId",
                table: "AspNetUsers",
                column: "ApplicationUserProfileId",
                principalTable: "AspNetUserProfiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUserAddresses_ApplicationUserAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUserProfiles_ApplicationUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserProfiles",
                table: "AspNetUserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserAddresses",
                table: "AspNetUserAddresses");

            migrationBuilder.RenameTable(
                name: "AspNetUserProfiles",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "AspNetUserAddresses",
                newName: "UserAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAddresses_ApplicationUserAddressId",
                table: "AspNetUsers",
                column: "ApplicationUserAddressId",
                principalTable: "UserAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfiles_ApplicationUserProfileId",
                table: "AspNetUsers",
                column: "ApplicationUserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
