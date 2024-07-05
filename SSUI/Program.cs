using SSUI.Services.Implementation.Administration;
using SSUI.Services.Implementation.EmployeeManagement.Master;

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
    builder.Services.AddHttpClient<ICountry, CountryServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Country/"); });
    builder.Services.AddHttpClient<ICompany, CompanyServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Company/"); });
    builder.Services.AddHttpClient<IUnit, UnitServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Unit/"); });
    builder.Services.AddHttpClient<IList, ListServices>(options => { options.BaseAddress = new Uri(ApiUrl + "List/"); });
    builder.Services.AddHttpClient<IBank, BankServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Bank/"); });
    builder.Services.AddHttpClient<IBankBranch, BankBranchServices>(options => { options.BaseAddress = new Uri(ApiUrl + "BankBranch/"); });
    builder.Services.AddHttpClient<IBranch, BranchServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Branch/"); });
    builder.Services.AddHttpClient<ICity, CityServices>(options => { options.BaseAddress = new Uri(ApiUrl + "City/"); });
    builder.Services.AddHttpClient<IDesignation, DesignationServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Designation/"); });
    builder.Services.AddHttpClient<IGrade, GradeServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Grade/"); });
    builder.Services.AddHttpClient<ILocations, LocationServices>(options => { options.BaseAddress = new Uri(ApiUrl + "Location/"); });

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