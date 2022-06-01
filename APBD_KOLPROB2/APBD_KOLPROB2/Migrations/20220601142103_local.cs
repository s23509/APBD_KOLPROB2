using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_KOLPROB2.Migrations
{
    public partial class local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 1, 16, 21, 2, 754, DateTimeKind.Local).AddTicks(9443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 1, 15, 1, 44, 71, DateTimeKind.Local).AddTicks(2438));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 1, 15, 1, 44, 71, DateTimeKind.Local).AddTicks(2438),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 1, 16, 21, 2, 754, DateTimeKind.Local).AddTicks(9443));
        }
    }
}
