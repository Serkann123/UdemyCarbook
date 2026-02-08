using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UdemyCarbook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDateTimesAndRemoveCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RendACarProcesses_Customers_CustomerId",
                table: "RendACarProcesses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_RendACarProcesses_CustomerId' 
                AND object_id = OBJECT_ID('RendACarProcesses'))
                BEGIN
                DROP INDEX [IX_RendACarProcesses_CustomerId] ON [RendACarProcesses];
                END
              ");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "RendACarProcesses");

            migrationBuilder.RenameColumn(
                name: "PickUpLocation",
                table: "RendACarProcesses",
                newName: "PickUpLocationId");

            migrationBuilder.RenameColumn(
                name: "DropOffLocation",
                table: "RendACarProcesses",
                newName: "DropOffLocationId");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpLocationId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DropOffLocationId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DropOffDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDateTime",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickUpDate",
                table: "RendACarProcesses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DropOffDate",
                table: "RendACarProcesses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOffDateTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PickUpDateTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PickUpLocationId",
                table: "RendACarProcesses",
                newName: "PickUpLocation");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationId",
                table: "RendACarProcesses",
                newName: "DropOffLocation");

            migrationBuilder.AlterColumn<int>(
                name: "PickUpLocationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DropOffLocationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickUpDate",
                table: "RendACarProcesses",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DropOffDate",
                table: "RendACarProcesses",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "RendACarProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RendACarProcesses_CustomerId",
                table: "RendACarProcesses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RendACarProcesses_Customers_CustomerId",
                table: "RendACarProcesses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
