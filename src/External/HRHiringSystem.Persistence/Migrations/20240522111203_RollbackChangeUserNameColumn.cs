using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRHiringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RollbackChangeUserNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0c767aa4-bbfb-41b1-8988-caf5a230c885");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e975a85-cb18-4a43-a112-e24e60b30b8e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "759ae74b-431d-4300-a4b3-2e7d4d24453f");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c4696fb-2563-4eb3-b8a5-9ffca00d49e8", null, "HRManager", "HRMANAGER" },
                    { "9bdb22f2-beeb-40ae-8f1c-f3327a14a9d8", null, "Recruiter", "RECRUITER" },
                    { "eb3e7889-45a2-48c3-876b-26428b0678d6", null, "Interviewer", "INTERVIEWER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c4696fb-2563-4eb3-b8a5-9ffca00d49e8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9bdb22f2-beeb-40ae-8f1c-f3327a14a9d8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eb3e7889-45a2-48c3-876b-26428b0678d6");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c767aa4-bbfb-41b1-8988-caf5a230c885", null, "Recruiter", "RECRUITER" },
                    { "1e975a85-cb18-4a43-a112-e24e60b30b8e", null, "HRManager", "HRMANAGER" },
                    { "759ae74b-431d-4300-a4b3-2e7d4d24453f", null, "Interviewer", "INTERVIEWER" }
                });
        }
    }
}
