using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRHiringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64ae102e-9a2b-449f-821c-136c2fa20bec", null, "Interviewer", "INTERVIEWER" },
                    { "706d9291-f1f8-4dcb-8588-b838c162f6fd", null, "HRManager", "HRMANAGER" },
                    { "79ccb11b-43f0-4aa4-8906-40b1293678f0", null, "Recruiter", "RECRUITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "64ae102e-9a2b-449f-821c-136c2fa20bec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "706d9291-f1f8-4dcb-8588-b838c162f6fd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "79ccb11b-43f0-4aa4-8906-40b1293678f0");
        }
    }
}
