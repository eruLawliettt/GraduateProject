using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateProject.entities.migrations
{
    public partial class shit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "report");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressRepots_SemesterId_Semesters_Id",
                        column: x => x.SemesterId,
                        principalSchema: "curriculum",
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_GroupId_Groups_Id",
                        column: x => x.GroupId,
                        principalSchema: "subject",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportMarks",
                schema: "report",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportMarks_ReportId_DisciplineId_StudentId", x => new { x.ReportId, x.DisciplineId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ReportMarks_DisciplineId_Disciplines_Id",
                        column: x => x.DisciplineId,
                        principalSchema: "curriculum",
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportMarks_ReportId_Reports_Id",
                        column: x => x.ReportId,
                        principalSchema: "report",
                        principalTable: "Reports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportMarks_StudentId_Students_Id",
                        column: x => x.StudentId,
                        principalSchema: "subject",
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplineSemesters_TeacherId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportMarks_DisciplineId",
                schema: "report",
                table: "ReportMarks",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportMarks_StudentId",
                schema: "report",
                table: "ReportMarks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_GroupId",
                schema: "report",
                table: "Reports",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SemesterId",
                schema: "report",
                table: "Reports",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanCycleDisciplineSemesters_TeacherId_Persons_Id",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                column: "TeacherId",
                principalSchema: "subject",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanCycleDisciplineSemesters_TeacherId_Persons_Id",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters");

            migrationBuilder.DropTable(
                name: "ReportMarks",
                schema: "report");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "report");

            migrationBuilder.DropIndex(
                name: "IX_PlanCycleDisciplineSemesters_TeacherId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters");
        }
    }
}
