namespace SSAPI.Context
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) :base (options)
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


        #endregion

    }
}
