using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalTaxCalculation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxBrackets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    TaxBracketJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBrackets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { 1, "US", "The United States of America" },
                    { 2, "VN", "Viet Nam" }
                });

            migrationBuilder.InsertData(
                table: "TaxBrackets",
                columns: new[] { "Id", "CountryCode", "TaxBracketJson" },
                values: new object[] { 1, "US", "[{\"Level\":1,\"Limit\":11000,\"Rate\":0.10},{\"Level\":2,\"Limit\":44725,\"Rate\":0.12},{\"Level\":3,\"Limit\":95375,\"Rate\":0.22},{\"Level\":4,\"Limit\":182100,\"Rate\":0.24},{\"Level\":5,\"Limit\":231250,\"Rate\":0.32},{\"Level\":6,\"Limit\":578125,\"Rate\":0.35},{\"Level\":7,\"Limit\":999999999999999.99,\"Rate\":0.37}]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "TaxBrackets");
        }
    }
}
