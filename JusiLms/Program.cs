using System.Configuration;
using JusiLms.Areas.Identity;
using JusiLms.Data;
using JusiLms.Models;
using JusiLms.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.ModelBuilder;
using MudBlazor.Services;
using JusiLms.Services.Api;
using Refit;
using JusiLms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var dockerPostgressConnectionString = Environment.GetEnvironmentVariable("DOCKER_POSTGRESS_CONNECTION_STRING");
var dockerApiHost = Environment.GetEnvironmentVariable("JUSI_API_HOST");
var runningInDockerString = Environment.GetEnvironmentVariable("RUNNING_IN_DOCKER");
var runningInDocker = !string.IsNullOrWhiteSpace(runningInDockerString) && bool.Parse(runningInDockerString);

if (!string.IsNullOrWhiteSpace(dockerPostgressConnectionString))
{
    connectionString = dockerPostgressConnectionString;
}


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<User, Role>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequiredLength = 4;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/Login";
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<CircuitHandler, TrackingCircuitHandler>();

builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<User>("Users");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(User));
    usersType.AddProperty(typeof(User).GetProperty(nameof(User.Password)));
    usersType.AddProperty(typeof(User).GetProperty(nameof(User.ConfirmPassword)));
    oDataBuilder.EntitySet<Role>("Roles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});

builder.Services.AddTransient<IInitializeService, InitializeService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ILessonsService, LessonsService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IHomeWorksService, HomeWorkService>();

builder.Services.Configure<FileServiceOptions>(builder.Configuration.GetSection(nameof(FileServiceOptions)));
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddMudServices();

/*builder.Services.AddSingleton(services =>
{
    // Get the address that the app is currently running at
    var server = services.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature.Addresses.First();
    return new HttpClient
    {
        BaseAddress = new Uri(baseAddress)
    };
});*/
builder.Services.AddHttpClient("cookie")
    .ConfigurePrimaryHttpMessageHandler(() => 
        new HttpClientHandler
        {
            UseCookies = true,
            UseDefaultCredentials = true
        });
builder.Services.AddScoped(services =>
{
    var contextAccessor = services.GetRequiredService<IHttpContextAccessor>();
    var context = contextAccessor.HttpContext;

    var server = services.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    var baseAddress = addressFeature.Addresses.First();

    var baseAddres = string.IsNullOrWhiteSpace(dockerApiHost) ? baseAddress : $"http://{dockerApiHost}";

    var client = services.GetRequiredService<IHttpClientFactory>().CreateClient("cookie");
    client.BaseAddress = new(baseAddres);

    client.DefaultRequestHeaders.Add("Cookie", context.Request.Headers["Cookie"].ToString());

    return client;
});
builder.Services.AddRefitApi<IUsersApi>();
builder.Services.AddRefitApi<ICategoryApi>();
builder.Services.AddRefitApi<IHomeWorksApi>();
builder.Services.AddRefitApi<ILessonsApi>();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

builder.Services.AddSingleton<IYoutubeEmbedUrlCreator, YoutubeEmbedUrlCreator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if(!runningInDocker)
{
    //app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await using (var scope = app.Services.CreateAsyncScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<IInitializeService>().InitializeAsync();
}

app.Run();
