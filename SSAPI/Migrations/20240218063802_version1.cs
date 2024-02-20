using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Subscription = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flgActive = table.Column<bool>(type: "bit", nullable: false),
                    flgDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserType = table.Column<bool>(type: "bit", nullable: false),
                    flgActive = table.Column<bool>(type: "bit", nullable: false),
                    flgDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitSize = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    flgActive = table.Column<bool>(type: "bit", nullable: false),
                    flgDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstUnit_MstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompany",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MstUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    flgActive = table.Column<bool>(type: "bit", nullable: false),
                    flgDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstUsers_MstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompany",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MstUsers_MstEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "MstEmployee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MstUsers_MstUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("5f8ff989-7b9b-48d2-9317-3dc871893605"), null, "Auto", new DateTime(2024, 2, 18, 11, 38, 2, 219, DateTimeKind.Local).AddTicks(2401), "", null, "super@123", null, "Auto", new DateTime(2024, 2, 18, 11, 38, 2, 219, DateTimeKind.Local).AddTicks(2410), "manager", 1, "Auto", true, false, "Auto" });

            migrationBuilder.CreateIndex(
                name: "IX_MstUnit_CompanyId",
                table: "MstUnit",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstUsers_CompanyId",
                table: "MstUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstUsers_EmployeeId",
                table: "MstUsers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstUsers_UnitId",
                table: "MstUsers",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstUsers");

            migrationBuilder.DropTable(
                name: "MstEmployee");

            migrationBuilder.DropTable(
                name: "MstUnit");

            migrationBuilder.DropTable(
                name: "MstCompany");
        }
    }
}
