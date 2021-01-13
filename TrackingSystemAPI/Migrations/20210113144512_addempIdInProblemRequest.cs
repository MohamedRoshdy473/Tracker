using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class addempIdInProblemRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "RequestProblemsDTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "RequestProblemsDTO",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "requestProblems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_requestProblems_EmployeeId",
                table: "requestProblems",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_requestProblems_Employees_EmployeeId",
                table: "requestProblems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requestProblems_Employees_EmployeeId",
                table: "requestProblems");

            migrationBuilder.DropIndex(
                name: "IX_requestProblems_EmployeeId",
                table: "requestProblems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "RequestProblemsDTO");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "RequestProblemsDTO");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "requestProblems");
        }
    }
}
