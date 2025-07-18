using newsite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// handle connection for local vs prod
var environment = builder.Environment;
string? connectionString;


if (environment.IsDevelopment())
{
	// Use connection string from appsettings.Development.json
	connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
	// Use environment variable in production
	//connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
	connectionString = builder.Configuration["DefaultConnection"];

	if (string.IsNullOrEmpty(connectionString))
	{
		throw new Exception("DefaultConnection environment variable not set.");
	}
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));



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


app.Run();
