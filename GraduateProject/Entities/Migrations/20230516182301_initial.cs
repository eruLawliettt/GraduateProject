﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateProject.entities.migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "curriculum");

            migrationBuilder.EnsureSchema(
                name: "subject");

            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "CertificationForms",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationForms_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyDirections",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyDirections_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalModules",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificationHours = table.Column<int>(type: "int", nullable: false),
                    CertificationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalModules_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalModules_CertificationFormId_CertificationForms_Id",
                        column: x => x.CertificationFormId,
                        principalSchema: "curriculum",
                        principalTable: "CertificationForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                schema: "subject",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions_EmployeeId_PositionId", x => new { x.EmployeeId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_EmployeePositions_PositionId_Positions_Id",
                        column: x => x.PositionId,
                        principalSchema: "subject",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyDirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupervisorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_StudyDirectionId_StudyDirections_Id",
                        column: x => x.StudyDirectionId,
                        principalSchema: "curriculum",
                        principalTable: "StudyDirections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "subject",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_UserId_Users_Id",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans_Id", x => x.Id);
                    table.ForeignKey(
                        name: "PK_Plans_GroupId_Groups_Id",
                        column: x => x.GroupId,
                        principalSchema: "subject",
                        principalTable: "Group",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanCycles",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCycles_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanCycles_CycleId_Cycles_Id",
                        column: x => x.CycleId,
                        principalSchema: "curriculum",
                        principalTable: "Cycles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCycles_PlanId_Plans_Id",
                        column: x => x.PlanId,
                        principalSchema: "curriculum",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_PlanId_Plan_Id",
                        column: x => x.PlanId,
                        principalSchema: "curriculum",
                        principalTable: "Plans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanCycleDisciplines",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanCycleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificationHours = table.Column<int>(type: "int", nullable: false),
                    ProfessionalModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCycleDisciplines_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanCycleDiscipline_DisciplineId_Disciplines_Id",
                        column: x => x.DisciplineId,
                        principalSchema: "curriculum",
                        principalTable: "Disciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCycleDiscipline_PlanCycleId_PlanCycles_Id",
                        column: x => x.PlanCycleId,
                        principalSchema: "curriculum",
                        principalTable: "PlanCycles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCycleDiscipline_ProfessionalModuleId_ProfessionalModules_Id",
                        column: x => x.ProfessionalModuleId,
                        principalSchema: "curriculum",
                        principalTable: "ProfessionalModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanCycleDisciplineSemesters",
                schema: "curriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanCycleDisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheoreticalHours = table.Column<int>(type: "int", nullable: false),
                    PracticalHours = table.Column<int>(type: "int", nullable: false),
                    CertificationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCycleDisciplineSemesters_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanCycleDisciplineSemesters_CertificationFormId_CertificationForms_Id",
                        column: x => x.CertificationFormId,
                        principalSchema: "curriculum",
                        principalTable: "CertificationForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCycleDisciplineSemesters_PlanCycleDisciplineId_PlanCycleDisciplines_Id",
                        column: x => x.PlanCycleDisciplineId,
                        principalSchema: "curriculum",
                        principalTable: "PlanCycleDisciplines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCycleDisciplineSemesters_SemesterId_Semesters_Id",
                        column: x => x.SemesterId,
                        principalSchema: "curriculum",
                        principalTable: "Semesters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                schema: "subject",
                table: "EmployeePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_StudyDirectionId",
                schema: "subject",
                table: "Group",
                column: "StudyDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_SupervisorId",
                schema: "subject",
                table: "Group",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GroupId",
                schema: "subject",
                table: "Persons",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                schema: "subject",
                table: "Persons",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplines_DisciplineId",
                schema: "curriculum",
                table: "PlanCycleDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplines_PlanCycleId_DisciplineId",
                schema: "curriculum",
                table: "PlanCycleDisciplines",
                columns: new[] { "PlanCycleId", "DisciplineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplines_ProfessionalModuleId",
                schema: "curriculum",
                table: "PlanCycleDisciplines",
                column: "ProfessionalModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplineSemesters_CertificationFormId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                column: "CertificationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplineSemesters_PlanCycleDisciplineId_SemesterId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                columns: new[] { "PlanCycleDisciplineId", "SemesterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycleDisciplineSemesters_SemesterId",
                schema: "curriculum",
                table: "PlanCycleDisciplineSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycles_CycleId",
                schema: "curriculum",
                table: "PlanCycles",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCycles_PlanId_CycleId",
                schema: "curriculum",
                table: "PlanCycles",
                columns: new[] { "PlanId", "CycleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_GroupId",
                schema: "curriculum",
                table: "Plans",
                column: "GroupId",
                unique: true,
                filter: "[GroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalModules_CertificationFormId",
                schema: "curriculum",
                table: "ProfessionalModules",
                column: "CertificationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_PlanId",
                schema: "curriculum",
                table: "Semesters",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePositions_EmployeeId_Employees_Id",
                schema: "subject",
                table: "EmployeePositions",
                column: "EmployeeId",
                principalSchema: "subject",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_SupervisorId_Employees_Id",
                schema: "subject",
                table: "Group",
                column: "SupervisorId",
                principalSchema: "subject",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_SupervisorId_Employees_Id",
                schema: "subject",
                table: "Group");

            migrationBuilder.DropTable(
                name: "EmployeePositions",
                schema: "subject");

            migrationBuilder.DropTable(
                name: "PlanCycleDisciplineSemesters",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "subject");

            migrationBuilder.DropTable(
                name: "PlanCycleDisciplines",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Semesters",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Disciplines",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "PlanCycles",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "ProfessionalModules",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Cycles",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "CertificationForms",
                schema: "curriculum");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "subject");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "subject");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "StudyDirections",
                schema: "curriculum");
        }
    }
}
