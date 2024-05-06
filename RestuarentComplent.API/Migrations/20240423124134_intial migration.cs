using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestuarentComplent.API.Migrations
{
    /// <inheritdoc />
    public partial class intialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTb",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTb", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CityTb",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTb", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityTb_CountryTb_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTb",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayTimePhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExplanationDateInEstablistment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerTb_CityTb_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTb",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTb_CountryTb_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTb",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstablismentTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablishmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablismentTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstablismentTb_CityTb_CityId",
                        column: x => x.CityId,
                        principalTable: "CityTb",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablismentTb_CountryTb_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTb",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTb_CountryId",
                table: "CityTb",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTb_CityId",
                table: "CustomerTb",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTb_CountryId",
                table: "CustomerTb",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablismentTb_CityId",
                table: "EstablismentTb",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablismentTb_CountryId",
                table: "EstablismentTb",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTb");

            migrationBuilder.DropTable(
                name: "EstablismentTb");

            migrationBuilder.DropTable(
                name: "CityTb");

            migrationBuilder.DropTable(
                name: "CountryTb");
        }
    }
}
