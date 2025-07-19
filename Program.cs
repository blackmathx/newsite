using newsite;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.HttpOverrides; 

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Database connection setup
string? connectionString = null;

if (builder.Environment.IsDevelopment())
{
	// Use connection string from appsettings.Development.json
	connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
else
{
	// Get connection string from environment variable provided by App Runner configuration
	var secretJson = Environment.GetEnvironmentVariable("dbConn");
	if (secretJson != null)
	{
		var secretDict = JsonSerializer.Deserialize<Dictionary<string, string>>(secretJson);

		// BO 7/19/25 Replace with TryGetValue
		// connectionString = secretDict["DBConnection"];
		if (secretDict != null && secretDict.TryGetValue("DBConnection", out var dbConn))
		{
			connectionString = dbConn;
		}
	}

	if (string.IsNullOrEmpty(connectionString))
	{
		throw new Exception("DefaultConnection environment variable not set.");
	}
}


builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<newsite.Services.PostRepository>();
builder.Services.AddScoped<newsite.Services.UserCommentRepository>();
builder.Services.AddScoped<newsite.Services.SubmissionRepository>();

builder.Services.AddControllersWithViews();

// Add this before app.UseRouting()
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}




// Add this early in the middleware pipeline
app.UseForwardedHeaders();
app.UseLogUrl(); // Your middleware


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
