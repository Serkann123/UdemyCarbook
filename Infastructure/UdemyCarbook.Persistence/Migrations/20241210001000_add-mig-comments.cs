using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addmigcomments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDatar",
                table: "Comments",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Comments",
                newName: "CreateDatar");
        }
    }
}
