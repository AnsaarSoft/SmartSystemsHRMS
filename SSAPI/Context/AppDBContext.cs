namespace SSAPI.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MstUser>().HasData(
                new MstUser
                {
                    Id = Guid.NewGuid(),
                    UserCode = "manager",
                    Password = "super@123",
                    UserType = 1,
                    Employee = null,
                    Unit = null,
                    Company = null,
                    CreatedBy = "Auto",
                    UpdatedBy = "Auto",
                    cAppStamp = "Auto",
                    uAppStamp = "Auto",
                });
        }


        #region All Tables
        public DbSet<MstUser> MstUsers { get; set; }
        //public DbSet<MstEmployee> MstEmployees { get; set; }
        public DbSet<MstBankBranch> MstBankBranches { get; set; }
        public DbSet<MstBank> MstBanks { get; set; }
        public DbSet<MstBranch> MstBranches { get; set; }
        public DbSet<MstCity> MstCities { get; set; }
        public DbSet<MstCountry> MstCountries { get; set; }
        public DbSet<MstDepartment> MstDepartments { get; set; }
        public DbSet<MstDesignation> MstDesignations { get; set; }
        public DbSet<MstGrade> MstGrades { get; set; }
        public DbSet<MstList> MstLists { get; set; }
        public DbSet<MstLocation> MstLocations { get; set; }
        public DbSet<MstEmpAttachment> MstEmpAttachments { get; set; }
        public DbSet<MstEmpDependent> MstEmpDependents { get; set; }
        public DbSet<MstEmpEducation> MstEmpEducations { get; set; }
        public DbSet<MstEmpExperience> MstEmpExperiences { get; set; }
        public DbSet<MstUnit> MstUnits { get; set; }
        public DbSet<MstCompany> MstCompanies { get; set; }
        public DbSet<CfgRole> CfgRoles { get; set; }
        public DbSet<CfgRoleDetail> CfgRoleDetails { get; set; }
        public DbSet<CfgMenu> CfgMenus { get; set; }

        #endregion

    }
}
