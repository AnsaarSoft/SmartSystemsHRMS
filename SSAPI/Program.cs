var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    //SQL Server
    builder.Services.AddDbContext<AppDBContext>(db =>
      db.UseSqlServer(builder.Configuration.GetConnectionString("AppString")), ServiceLifetime.Scoped);
    //SQL Lite
    //builder.Services.AddDbContext<AppDBContext>(db =>
    //{
    //    var HostContent = builder.Configuration[HostDefaults.ContentRootKey];
    //    var path = Path.Combine(Path.GetDirectoryName(HostContent),"Context", builder.Configuration.GetConnectionString("DBName"));
    //    db.UseSqlite($"Data Source={path}");
    //});
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    #region Register DB Services
    builder.Services.AddScoped<IMstUser, MstUserService>();
    builder.Services.AddScoped<IMstDepartment, MstDepartmentService>();
    builder.Services.AddScoped<IMstCountry, MstCountryService>();
    builder.Services.AddScoped<IMstCompany, MstCompanyService>();
    builder.Services.AddScoped<IMstList, MstListService>();
    builder.Services.AddScoped<IMstBank, MstBankService>();
    builder.Services.AddScoped<IMstBankBranch, MstBankBranchService>();
    builder.Services.AddScoped<IMstBranch, MstBranchService>();
    builder.Services.AddScoped<IMstCity, MstCityService>();
    builder.Services.AddScoped<IMstDesignation, MstDesignationService>();
    builder.Services.AddScoped<IMstGrade, MstGradeService>();
    builder.Services.AddScoped<IMstLocation, MstLocationService>();
    builder.Services.AddScoped<IMstUnit, MstUnitService>();
    builder.Services.AddScoped<IMstEmployee, MstEmployeeService>();
    builder.Services.AddScoped<IMstEmpExperience, MstEmpExperienceService>();
    builder.Services.AddScoped<IMstEmpEducation, MstEmpEducationService>();
    builder.Services.AddScoped<IMstEmpDependent, MstEmpDependentService>();
    #endregion

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex);
}
finally
{
    LogManager.Shutdown();
}