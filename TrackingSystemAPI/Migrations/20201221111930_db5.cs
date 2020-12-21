using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GraduatioYear",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HiringDateHiringDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RelevantPhone",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(nullable: true),
                    OrganizationCode = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false),
                    ResponsiblePerson = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projectPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requestCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requestCategories_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requestPeriorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    periorty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestPeriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "requestSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(nullable: true),
                    RequestCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requestSubCategories_requestCategories_RequestCategoryId",
                        column: x => x.RequestCategoryId,
                        principalTable: "requestCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    ProjectPeriod = table.Column<int>(nullable: false),
                    PlanndedStartDate = table.Column<DateTime>(nullable: false),
                    ActualStartDate = table.Column<DateTime>(nullable: false),
                    PlanndedEndDate = table.Column<DateTime>(nullable: false),
                    ActualEndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "mileStones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mileStones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mileStones_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectDocuments_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    ProjectPositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectTeams_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectTeams_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projectTeams_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_projectTeams_projectPositions_ProjectPositionId",
                        column: x => x.ProjectPositionId,
                        principalTable: "projectPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(nullable: true),
                    RequestCode = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RequestSubCategoryId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RequestStatusId = table.Column<int>(nullable: false),
                    RequestPeriorityId = table.Column<int>(nullable: false),
                    RequestTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_requests_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_requestPeriorities_RequestPeriorityId",
                        column: x => x.RequestPeriorityId,
                        principalTable: "requestPeriorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_requestStatuses_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "requestStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_requestSubCategories_RequestSubCategoryId",
                        column: x => x.RequestSubCategoryId,
                        principalTable: "requestSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requests_requestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "requestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stackeholders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StackeholderName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stackeholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stackeholders_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_OrganizationId",
                table: "clients",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_mileStones_ProjectId",
                table: "mileStones",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectDocuments_ProjectId",
                table: "projectDocuments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_ClientId",
                table: "projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_EmployeeId",
                table: "projects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_projects_OrganizationId",
                table: "projects",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_DepartmentId",
                table: "projectTeams",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_EmployeeId",
                table: "projectTeams",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_ProjectId",
                table: "projectTeams",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_projectTeams_ProjectPositionId",
                table: "projectTeams",
                column: "ProjectPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_requestCategories_DepartmentId",
                table: "requestCategories",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_ProjectId",
                table: "requests",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestPeriorityId",
                table: "requests",
                column: "RequestPeriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestStatusId",
                table: "requests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestSubCategoryId",
                table: "requests",
                column: "RequestSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_requests_RequestTypeId",
                table: "requests",
                column: "RequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_requestSubCategories_RequestCategoryId",
                table: "requestSubCategories",
                column: "RequestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_stackeholders_ProjectId",
                table: "stackeholders",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "mileStones");

            migrationBuilder.DropTable(
                name: "projectDocuments");

            migrationBuilder.DropTable(
                name: "projectTeams");

            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "stackeholders");

            migrationBuilder.DropTable(
                name: "projectPositions");

            migrationBuilder.DropTable(
                name: "requestPeriorities");

            migrationBuilder.DropTable(
                name: "requestStatuses");

            migrationBuilder.DropTable(
                name: "requestSubCategories");

            migrationBuilder.DropTable(
                name: "requestTypes");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "requestCategories");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "EmployeeCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GraduatioYear",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HiringDateHiringDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelevantPhone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
