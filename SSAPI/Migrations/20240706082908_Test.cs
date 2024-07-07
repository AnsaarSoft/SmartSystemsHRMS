using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("937300f9-098f-4b73-896a-dc81ce8ca2a1"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("3085f2ea-4afa-4caa-a9e9-5137867838d5"), null, "Auto", new DateTime(2024, 7, 6, 13, 29, 8, 45, DateTimeKind.Local).AddTicks(9545), "", null, "super@123", null, "Auto", new DateTime(2024, 7, 6, 13, 29, 8, 45, DateTimeKind.Local).AddTicks(9556), "manager", 1, "Auto", true, false, "Auto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("3085f2ea-4afa-4caa-a9e9-5137867838d5"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("937300f9-098f-4b73-896a-dc81ce8ca2a1"), null, "Auto", new DateTime(2024, 6, 10, 21, 27, 44, 123, DateTimeKind.Local).AddTicks(5174), "", null, "super@123", null, "Auto", new DateTime(2024, 6, 10, 21, 27, 44, 123, DateTimeKind.Local).AddTicks(5188), "manager", 1, "Auto", true, false, "Auto" });
        }
    }
}
