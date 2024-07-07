using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class BankFieldsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("455073d4-18ac-49f4-9287-bc40d497626b"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("b0720623-4d22-4d62-b13d-fe57f739ae12"), null, "Auto", new DateTime(2024, 7, 7, 10, 8, 4, 158, DateTimeKind.Local).AddTicks(3026), "", null, "super@123", null, "Auto", new DateTime(2024, 7, 7, 10, 8, 4, 158, DateTimeKind.Local).AddTicks(3040), "manager", 1, "Auto", true, false, "Auto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("b0720623-4d22-4d62-b13d-fe57f739ae12"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("455073d4-18ac-49f4-9287-bc40d497626b"), null, "Auto", new DateTime(2024, 7, 6, 20, 3, 16, 550, DateTimeKind.Local).AddTicks(915), "", null, "super@123", null, "Auto", new DateTime(2024, 7, 6, 20, 3, 16, 550, DateTimeKind.Local).AddTicks(933), "manager", 1, "Auto", true, false, "Auto" });
        }
    }
}
