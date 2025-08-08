using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_tables_columns_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentACarId",
                table: "RendACars",
                newName: "RendACarId");

            migrationBuilder.RenameColumn(
                name: "CommnentId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameColumn(
                name: "BranId",
                table: "Brands",
                newName: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RendACarId",
                table: "RendACars",
                newName: "RentACarId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "CommnentId");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Brands",
                newName: "BranId");
        }
    }
}
