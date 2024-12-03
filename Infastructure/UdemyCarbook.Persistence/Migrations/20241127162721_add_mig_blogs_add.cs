using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_blogs_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descrpiton",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrpiton",
                table: "Blogs");
        }
    }
}
