using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateProject.entities.migrations
{
    public partial class reporttoprogressreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExamReportId",
                schema: "report",
                table: "ReportMarks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportMarks_ExamReportId",
                schema: "report",
                table: "ReportMarks",
                column: "ExamReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportMarks_Reports_ExamReportId",
                schema: "report",
                table: "ReportMarks",
                column: "ExamReportId",
                principalSchema: "report",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportMarks_Reports_ExamReportId",
                schema: "report",
                table: "ReportMarks");

            migrationBuilder.DropIndex(
                name: "IX_ReportMarks_ExamReportId",
                schema: "report",
                table: "ReportMarks");

            migrationBuilder.DropColumn(
                name: "ExamReportId",
                schema: "report",
                table: "ReportMarks");
        }
    }
}
