using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionDate",
                table: "UserActions",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 29, 21, 1, 53, 426, DateTimeKind.Local).AddTicks(8257));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ActionDate",
                table: "UserActions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 29, 21, 1, 53, 426, DateTimeKind.Local).AddTicks(8257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
