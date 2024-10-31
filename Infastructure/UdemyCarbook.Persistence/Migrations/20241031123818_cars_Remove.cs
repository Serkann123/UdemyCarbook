using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cars_Remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CarFeatures_Cars_CarId",
                table: "CarFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Cars_CarId",
                table: "CarPricings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_CarId",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarFeatures_CarId",
                table: "CarFeatures");

            migrationBuilder.DropIndex(
                name: "IX_CarDescriptions_CarId",
                table: "CarDescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    BigImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandBranId = table.Column<int>(type: "int", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Luggage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Seat = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandBranId",
                        column: x => x.BrandBranId,
                        principalTable: "Brands",
                        principalColumn: "BranId");
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BranId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_CarId",
                table: "CarPricings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarFeatures_CarId",
                table: "CarFeatures",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDescriptions_CarId",
                table: "CarDescriptions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandBranId",
                table: "Cars",
                column: "BrandBranId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarFeatures_Cars_CarId",
                table: "CarFeatures",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Cars_CarId",
                table: "CarPricings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
