using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalClinicWebApi.DAL.Data.Migrations
{
    public partial class AddResultsNotesColumnToLabOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabOrder_AspNetUsers_PatientId",
                table: "LabOrder");

            migrationBuilder.DropTable(
                name: "LabResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabOrder",
                table: "LabOrder");

            migrationBuilder.RenameTable(
                name: "LabOrder",
                newName: "LabOrders");

            migrationBuilder.RenameIndex(
                name: "IX_LabOrder_PatientId",
                table: "LabOrders",
                newName: "IX_LabOrders_PatientId");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "LabOrders",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabOrders",
                table: "LabOrders",
                column: "LabOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabOrders_AspNetUsers_PatientId",
                table: "LabOrders",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabOrders_AspNetUsers_PatientId",
                table: "LabOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LabOrders",
                table: "LabOrders");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "LabOrders");

            migrationBuilder.RenameTable(
                name: "LabOrders",
                newName: "LabOrder");

            migrationBuilder.RenameIndex(
                name: "IX_LabOrders_PatientId",
                table: "LabOrder",
                newName: "IX_LabOrder_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabOrder",
                table: "LabOrder",
                column: "LabOrderId");

            migrationBuilder.CreateTable(
                name: "LabResult",
                columns: table => new
                {
                    LabResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabOrderId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultsDate = table.Column<DateTime>(type: "SmallDateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabResult", x => x.LabResultId);
                    table.ForeignKey(
                        name: "FK_LabResult_LabOrder_LabOrderId",
                        column: x => x.LabOrderId,
                        principalTable: "LabOrder",
                        principalColumn: "LabOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabResult_LabOrderId",
                table: "LabResult",
                column: "LabOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LabOrder_AspNetUsers_PatientId",
                table: "LabOrder",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
