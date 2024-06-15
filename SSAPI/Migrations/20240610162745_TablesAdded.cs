using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("de248372-10d5-474b-8e8e-02c45c3b4504"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("937300f9-098f-4b73-896a-dc81ce8ca2a1"), null, "Auto", new DateTime(2024, 6, 10, 21, 27, 44, 123, DateTimeKind.Local).AddTicks(5174), "", null, "super@123", null, "Auto", new DateTime(2024, 6, 10, 21, 27, 44, 123, DateTimeKind.Local).AddTicks(5188), "manager", 1, "Auto", true, false, "Auto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("937300f9-098f-4b73-896a-dc81ce8ca2a1"));

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("de248372-10d5-474b-8e8e-02c45c3b4504"), null, "Auto", new DateTime(2024, 5, 19, 8, 44, 16, 950, DateTimeKind.Local).AddTicks(7898), "", null, "super@123", null, "Auto", new DateTime(2024, 5, 19, 8, 44, 16, 950, DateTimeKind.Local).AddTicks(7911), "manager", 1, "Auto", true, false, "Auto" });
        }
    }
}
