using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab1.Migrations
{
    /// <inheritdoc />
    public partial class intial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_Departmentdeptid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Departmentdeptid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Departmentdeptid",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "deptid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Departmentdeptid",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Departmentdeptid",
                table: "Users",
                column: "Departmentdeptid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_Departmentdeptid",
                table: "Users",
                column: "Departmentdeptid",
                principalTable: "Departments",
                principalColumn: "deptid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
