using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.EntityFrameworkCore;
using MultiLangDemo;
using MultiLangDemo.Data;
using MultiLangDemo.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add localization services and configure the resources path
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

// Add MVC services and enable view localization
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider =
            (type, factory) =>
            {
                return factory.Create(
                    typeof(SharedResource));
            };
    });

// Define the supported cultures for localization
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("hi")
};
// Configure the request localization options
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders =
    new List<IRequestCultureProvider>
    {
        new RouteDataRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<DatabaseLocalizer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var localizationOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{culture=en}/{controller=Home}/{action=Index}/{id?}");

app.Run();
