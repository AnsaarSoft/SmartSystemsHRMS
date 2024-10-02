using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSAPI.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstUnit_MstCompany_CompanyId",
                table: "MstUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstCompany_CompanyId",
                table: "MstUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstEmployee_EmployeeId",
                table: "MstUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstUnit_UnitId",
                table: "MstUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstUnit",
                table: "MstUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstEmployee",
                table: "MstEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstCompany",
                table: "MstCompany");

            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("3675b18d-071d-4d86-8a93-343a43dd07e3"));

            migrationBuilder.RenameTable(
                name: "MstUnit",
                newName: "MstUnits");

            migrationBuilder.RenameTable(
                name: "MstEmployee",
                newName: "MstEmployees");

            migrationBuilder.RenameTable(
                name: "MstCompany",
                newName: "MstCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_MstUnit_CompanyId",
                table: "MstUnits",
                newName: "IX_MstUnits_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstUnits",
                table: "MstUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstEmployees",
                table: "MstEmployees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstCompanies",
                table: "MstCompanies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CfgMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    flgHead = table.Column<bool>(type: "bit", nullable: false),
                    flgForm = table.Column<bool>(type: "bit", nullable: false),
                    FormUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FormIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_CfgMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfgMenus_CfgMenus_ParentFormId",
                        column: x => x.ParentFormId,
                        principalTable: "CfgMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CfgRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DocSeries = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SortNo = table.Column<int>(type: "int", nullable: false),
                    DocNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_CfgRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstBanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstBanks_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstBanks_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstBranches_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstBranches_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstDepartments_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstDepartments_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstDesignations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstDesignations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstDesignations_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstDesignations_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstEmpAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    table.PrimaryKey("PK_MstEmpAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstEmpAttachments_MstEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "MstEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstEmpEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DegreeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_MstEmpEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstEmpEducations_MstEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "MstEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstEmpExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_MstEmpExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstEmpExperiences_MstEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "MstEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstGrades_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstGrades_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstLocations_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstLocations_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CfgRoleDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    flgView = table.Column<bool>(type: "bit", nullable: false),
                    flgEdit = table.Column<bool>(type: "bit", nullable: false),
                    flgAdmin = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CfgRoleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfgRoleDetails_CfgMenus_FormId",
                        column: x => x.FormId,
                        principalTable: "CfgMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CfgRoleDetails_CfgRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "CfgRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstBankBranches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_MstBankBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstBankBranches_MstBanks_BankId",
                        column: x => x.BankId,
                        principalTable: "MstBanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstBankBranches_MstCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "MstCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstBankBranches_MstUnits_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MstUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_MstCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstCities_MstCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "MstCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MstEmpDependents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalCardNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_MstEmpDependents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MstEmpDependents_MstEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "MstEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MstEmpDependents_MstLists_RelationId",
                        column: x => x.RelationId,
                        principalTable: "MstLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("de248372-10d5-474b-8e8e-02c45c3b4504"), null, "Auto", new DateTime(2024, 5, 19, 8, 44, 16, 950, DateTimeKind.Local).AddTicks(7898), "", null, "super@123", null, "Auto", new DateTime(2024, 5, 19, 8, 44, 16, 950, DateTimeKind.Local).AddTicks(7911), "manager", 1, "Auto", true, false, "Auto" });

            migrationBuilder.CreateIndex(
                name: "IX_CfgMenus_ParentFormId",
                table: "CfgMenus",
                column: "ParentFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CfgRoleDetails_FormId",
                table: "CfgRoleDetails",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_CfgRoleDetails_RoleId",
                table: "CfgRoleDetails",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBankBranches_BankId",
                table: "MstBankBranches",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBankBranches_CompanyId",
                table: "MstBankBranches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBankBranches_UnitId",
                table: "MstBankBranches",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBanks_CompanyId",
                table: "MstBanks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBanks_UnitId",
                table: "MstBanks",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBranches_CompanyId",
                table: "MstBranches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstBranches_UnitId",
                table: "MstBranches",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstCities_CountryId",
                table: "MstCities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MstDepartments_CompanyId",
                table: "MstDepartments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstDepartments_UnitId",
                table: "MstDepartments",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstDesignations_CompanyId",
                table: "MstDesignations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstDesignations_UnitId",
                table: "MstDesignations",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstEmpAttachments_EmployeeId",
                table: "MstEmpAttachments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstEmpDependents_EmployeeId",
                table: "MstEmpDependents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstEmpDependents_RelationId",
                table: "MstEmpDependents",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_MstEmpEducations_EmployeeId",
                table: "MstEmpEducations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstEmpExperiences_EmployeeId",
                table: "MstEmpExperiences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MstGrades_CompanyId",
                table: "MstGrades",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstGrades_UnitId",
                table: "MstGrades",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MstLocations_CompanyId",
                table: "MstLocations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MstLocations_UnitId",
                table: "MstLocations",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_MstUnits_MstCompanies_CompanyId",
                table: "MstUnits",
                column: "CompanyId",
                principalTable: "MstCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstCompanies_CompanyId",
                table: "MstUsers",
                column: "CompanyId",
                principalTable: "MstCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstEmployees_EmployeeId",
                table: "MstUsers",
                column: "EmployeeId",
                principalTable: "MstEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstUnits_UnitId",
                table: "MstUsers",
                column: "UnitId",
                principalTable: "MstUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MstUnits_MstCompanies_CompanyId",
                table: "MstUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstCompanies_CompanyId",
                table: "MstUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstEmployees_EmployeeId",
                table: "MstUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUsers_MstUnits_UnitId",
                table: "MstUsers");

            migrationBuilder.DropTable(
                name: "CfgRoleDetails");

            migrationBuilder.DropTable(
                name: "MstBankBranches");

            migrationBuilder.DropTable(
                name: "MstBranches");

            migrationBuilder.DropTable(
                name: "MstCities");

            migrationBuilder.DropTable(
                name: "MstDepartments");

            migrationBuilder.DropTable(
                name: "MstDesignations");

            migrationBuilder.DropTable(
                name: "MstEmpAttachments");

            migrationBuilder.DropTable(
                name: "MstEmpDependents");

            migrationBuilder.DropTable(
                name: "MstEmpEducations");

            migrationBuilder.DropTable(
                name: "MstEmpExperiences");

            migrationBuilder.DropTable(
                name: "MstGrades");

            migrationBuilder.DropTable(
                name: "MstLocations");

            migrationBuilder.DropTable(
                name: "CfgMenus");

            migrationBuilder.DropTable(
                name: "CfgRoles");

            migrationBuilder.DropTable(
                name: "MstBanks");

            migrationBuilder.DropTable(
                name: "MstCountries");

            migrationBuilder.DropTable(
                name: "MstLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstUnits",
                table: "MstUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstEmployees",
                table: "MstEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MstCompanies",
                table: "MstCompanies");

            migrationBuilder.DeleteData(
                table: "MstUsers",
                keyColumn: "Id",
                keyValue: new Guid("de248372-10d5-474b-8e8e-02c45c3b4504"));

            migrationBuilder.RenameTable(
                name: "MstUnits",
                newName: "MstUnit");

            migrationBuilder.RenameTable(
                name: "MstEmployees",
                newName: "MstEmployee");

            migrationBuilder.RenameTable(
                name: "MstCompanies",
                newName: "MstCompany");

            migrationBuilder.RenameIndex(
                name: "IX_MstUnits_CompanyId",
                table: "MstUnit",
                newName: "IX_MstUnit_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstUnit",
                table: "MstUnit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstEmployee",
                table: "MstEmployee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MstCompany",
                table: "MstCompany",
                column: "Id");

            migrationBuilder.InsertData(
                table: "MstUsers",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Email", "EmployeeId", "Password", "UnitId", "UpdatedBy", "UpdatedDate", "UserCode", "UserType", "cAppStamp", "flgActive", "flgDelete", "uAppStamp" },
                values: new object[] { new Guid("3675b18d-071d-4d86-8a93-343a43dd07e3"), null, "Auto", new DateTime(2024, 2, 25, 19, 45, 34, 196, DateTimeKind.Local).AddTicks(8561), "", null, "super@123", null, "Auto", new DateTime(2024, 2, 25, 19, 45, 34, 196, DateTimeKind.Local).AddTicks(8573), "manager", 1, "Auto", true, false, "Auto" });

            migrationBuilder.AddForeignKey(
                name: "FK_MstUnit_MstCompany_CompanyId",
                table: "MstUnit",
                column: "CompanyId",
                principalTable: "MstCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstCompany_CompanyId",
                table: "MstUsers",
                column: "CompanyId",
                principalTable: "MstCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstEmployee_EmployeeId",
                table: "MstUsers",
                column: "EmployeeId",
                principalTable: "MstEmployee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstUsers_MstUnit_UnitId",
                table: "MstUsers",
                column: "UnitId",
                principalTable: "MstUnit",
                principalColumn: "Id");
        }
    }
}
