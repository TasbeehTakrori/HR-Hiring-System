using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRHiringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNametoUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f4d4239-dec4-4090-8d2e-cebf29572972", null, "HRManager", "HRMANAGER" },
                    { "717c683e-6a85-43a5-8bc6-be308b51fe2d", null, "Interviewer", "INTERVIEWER" },
                    { "d5601e83-25d3-4e8c-883a-bc4d897e012e", null, "Recruiter", "RECRUITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f4d4239-dec4-4090-8d2e-cebf29572972");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "717c683e-6a85-43a5-8bc6-be308b51fe2d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5601e83-25d3-4e8c-883a-bc4d897e012e");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Users");

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
    }
}
