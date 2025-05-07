using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartCoffeeMachine.Migrations
{
    /// <inheritdoc />
    public partial class AddLogDateAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeekNumber",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HourSlot",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LogDate",
                table: "Logs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Logs_Action_DayOfWeekNumber_LogDate_HourSlot",
                table: "Logs",
                columns: new[] { "Action", "DayOfWeekNumber", "LogDate", "HourSlot" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Logs_Action_DayOfWeekNumber_LogDate_HourSlot",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "DayOfWeekNumber",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HourSlot",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LogDate",
                table: "Logs");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
