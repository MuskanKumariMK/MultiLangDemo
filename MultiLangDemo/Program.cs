using Microsoft.AspNetCore.Localization;
using MultiLangDemo;
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
});


var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
// Use the configured request localization options
app.UseRequestLocalization(
    localizationOptions.Value);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
