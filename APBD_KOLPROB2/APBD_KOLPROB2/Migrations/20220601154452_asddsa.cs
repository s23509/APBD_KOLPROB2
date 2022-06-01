using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_KOLPROB2.Migrations
{
    public partial class asddsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 1, 17, 44, 52, 319, DateTimeKind.Local).AddTicks(7006),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 1, 16, 21, 2, 754, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssignmentDate" },
                values: new object[] { 2, 3, new DateTime(2022, 5, 21, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFireTruck" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.AlterColumn<DateTime>(
                name: "AssignmentDate",
                table: "FireTruck_Action",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 1, 16, 21, 2, 754, DateTimeKind.Local).AddTicks(9443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 1, 17, 44, 52, 319, DateTimeKind.Local).AddTicks(7006));
        }
    }
}
