using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorWebApp_Silicon.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserAddressId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserProfileId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserAddressId",
                table: "AspNetUsers",
                column: "ApplicationUserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ApplicationUserProfileId",
                table: "AspNetUsers",
                column: "ApplicationUserProfileId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAddresses_ApplicationUserAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfiles_ApplicationUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ApplicationUserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserAddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserProfileId",
                table: "AspNetUsers");
        }
    }
}
