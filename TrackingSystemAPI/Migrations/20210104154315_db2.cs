using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackingSystemAPI.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "assignedRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_assignedRequests_EmployeeId",
                table: "assignedRequests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedRequests_Employees_EmployeeId",
                table: "assignedRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedRequests_Employees_EmployeeId",
                table: "assignedRequests");

            migrationBuilder.DropIndex(
                name: "IX_assignedRequests_EmployeeId",
                table: "assignedRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "assignedRequests");
        }
    }
}
