using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class bankbranch_field_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("3085f2ea-4afa-4caa-a9e9-5137867838d5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "MstBankBranches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("455073d4-18ac-49f4-9287-bc40d497626b"), null, "Auto", new DateTime(2024, 7, 6, 20, 3, 16, 550, DateTimeKind.Local).AddTicks(915), "", null, "super@123", null, "Auto", new DateTime(2024, 7, 6, 20, 3, 16, 550, DateTimeKind.Local).AddTicks(933), "manager", 1, "Auto", true, false, "Auto" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("455073d4-18ac-49f4-9287-bc40d497626b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "MstBankBranches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("3085f2ea-4afa-4caa-a9e9-5137867838d5"), null, "Auto", new DateTime(2024, 7, 6, 13, 29, 8, 45, DateTimeKind.Local).AddTicks(9545), "", null, "super@123", null, "Auto", new DateTime(2024, 7, 6, 13, 29, 8, 45, DateTimeKind.Local).AddTicks(9556), "manager", 1, "Auto", true, false, "Auto" });
        }
    }
}
