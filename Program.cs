using newsite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// This automatically loads appsettings.json + appsettings.Development.json (in Development)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<newsite.Services.EmployeeRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

// Map any routes that match the pattern "/{action=Index}" to the Home controller methods.
app.MapControllerRoute(
    name: "WelcomeRoute",
    pattern: "/{action=Index}",
    defaults: new { controller = "Home" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
