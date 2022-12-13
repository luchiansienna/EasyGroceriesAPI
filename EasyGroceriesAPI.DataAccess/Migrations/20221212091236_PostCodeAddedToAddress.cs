using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGroceriesAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PostCodeAddedToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Address",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Address");
        }
    }
}
