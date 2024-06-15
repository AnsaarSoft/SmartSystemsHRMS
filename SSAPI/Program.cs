var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    //SQL Server
    builder.Services.AddDbContext<AppDBContext>(db =>
      db.UseSqlServer(builder.Configuration.GetConnectionString("AppString")), ServiceLifetime.Singleton);
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
    //builder.Services.AddScoped<IMstEmployee, MstEmployeeService>();

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