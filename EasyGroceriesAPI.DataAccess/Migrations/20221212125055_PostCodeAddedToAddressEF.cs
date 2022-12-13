using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGroceriesAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PostCodeAddedToAddressEF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Address",
                newName: "CountryCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Address",
                newName: "Country");
        }
    }
}
