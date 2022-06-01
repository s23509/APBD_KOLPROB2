using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_KOLPROB2.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeedSpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruck_pk", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Action",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 1, 14, 54, 46, 835, DateTimeKind.Local).AddTicks(8524))
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruckAction.pk", x => new { x.IdFireTruck, x.IdAction });
                    table.ForeignKey(
                        name: "FireTruckAction_Action",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FireTruckAction_FireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTruck",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 28, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, null, true, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFireTruck", "OperationNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "1", true },
                    { 2, "11", false },
                    { 3, "113", false },
                    { 4, "2137", true }
                });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssignmentDate" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 1, 2, new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 4, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 4, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdAction",
                table: "FireTruck_Action",
                column: "IdAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireTruck_Action");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireTruck");
        }
    }
}
