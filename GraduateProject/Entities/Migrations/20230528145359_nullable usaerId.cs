using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateProject.entities.migrations
{
    public partial class nullableusaerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_UserId_Users_Id",
                schema: "subject",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                schema: "subject",
                table: "Persons");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "subject",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                schema: "subject",
                table: "Persons",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_UserId_Users_Id",
                schema: "subject",
                table: "Persons",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_UserId_Users_Id",
                schema: "subject",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                schema: "subject",
                table: "Persons");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "subject",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                schema: "subject",
                table: "Persons",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_UserId_Users_Id",
                schema: "subject",
                table: "Persons",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
