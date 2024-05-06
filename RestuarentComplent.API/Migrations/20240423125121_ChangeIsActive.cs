using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestuarentComplent.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "CustomerTb",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "CustomerTb",
                newName: "IsDelete");
        }
    }
}
