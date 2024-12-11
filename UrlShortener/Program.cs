using Microsoft.EntityFrameworkCore;
using UrlShortener.AppDbContext;
using UrlShortener.Interfaces;
using UrlShortener.Profiles;
using UrlShortener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IURLShortenerService, URLShortenerService>();
builder.Services.AddAutoMapper(typeof(AutoMapping));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "shortLink",
    pattern: "{shortCode}",
    defaults: new { controller = "URLShortener", action = "RedirectToLongURL" }); // This handles the redirect


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=URLShortener}/{action=Index}/{id?}");

app.Run();
