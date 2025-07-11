using newsite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// This automatically loads appsettings.json + appsettings.Development.json (in Development)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<newsite.Services.PostRepository>();
builder.Services.AddScoped<newsite.Services.UserCommentRepository>();
builder.Services.AddScoped<newsite.Services.SubmissionRepository>();

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


using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<AppDbContext>();
	Console.WriteLine("Applying migrations...");
	context.Database.Migrate();
	Console.WriteLine("Migrations applied successfully.");
}


app.Run();
