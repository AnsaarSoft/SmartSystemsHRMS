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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Subscription = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    flgActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    flgDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FatherName = table.Column<string>(type: "TEXT", nullable: false),
                    MotherName = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ServiceStartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ServiceEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    HomeAddress = table.Column<string>(type: "TEXT", nullable: false),
                    HomePhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HomeEmail = table.Column<string>(type: "TEXT", nullable: false),
                    HomeCity = table.Column<string>(type: "TEXT", nullable: false),
                    HomeCountry = table.Column<string>(type: "TEXT", nullable: false),
                    WorkAddress = table.Column<string>(type: "TEXT", nullable: false),
                    WorkPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    WorkEmail = table.Column<string>(type: "TEXT", nullable: false),
                    WorkCity = table.Column<string>(type: "TEXT", nullable: false),
                    WorkCountry = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserType = table.Column<bool>(type: "INTEGER", nullable: false),
                    flgActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    flgDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    UnitSize = table.Column<int>(type: "INTEGER", nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    flgActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    flgDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    UserType = table.Column<ushort>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UnitId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    flgActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    flgDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    uAppStamp = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
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
                values: new object[] { new Guid("a715f91f-ac4c-46c5-bd27-2689ad1fbb56"), null, "Auto", new DateTime(2024, 2, 21, 10, 54, 13, 330, DateTimeKind.Local).AddTicks(7724), "", null, "super@123", null, "Auto", new DateTime(2024, 2, 21, 10, 54, 13, 330, DateTimeKind.Local).AddTicks(7732), "manager", (ushort)1, "Auto", true, false, "Auto" });

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
