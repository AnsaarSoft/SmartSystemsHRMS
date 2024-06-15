using SSUI.Services.Implementation.EmployeeManagement.Master;
using SSUI.Services.Interface.EmployeeManagement.Master;

var logger = LogManager.Setup().LoadConfigurationFromFile().GetCurrentClassLogger();
try
{



    var builder = WebApplication.CreateBuilder(args);
    var config = builder.Configuration.GetSection("APIURL");
    string ApiUrl = config.Value.ToString();

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

    //builder.Services.AddAuthorization();
    builder.Services.AddScoped<AuthenticationStateProvider, AppAuth>();
    builder.Services.AddScoped<IDepartment, DepartmentService>();

    builder.Services.AddAuthorizationCore();
    //builder.Services.AddMudServices();
    builder.Services.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
        config.SnackbarConfiguration.PreventDuplicates = true;
        config.SnackbarConfiguration.NewestOnTop = false;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.VisibleStateDuration = 1000;
        config.SnackbarConfiguration.HideTransitionDuration = 500;
        config.SnackbarConfiguration.ShowTransitionDuration = 500;
        config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        config.SnackbarConfiguration.MaxDisplayedSnackbars = 1;
    });

    builder.Services.AddHttpClient<IUser, UserService>(options => { options.BaseAddress = new Uri(ApiUrl + "user/"); });
    builder.Services.AddHttpClient<IDepartment, DepartmentService>(options => { options.BaseAddress = new Uri(ApiUrl + "Department/"); });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();
    //app.UseAuthentication();
    //app.UseAuthorization();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

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