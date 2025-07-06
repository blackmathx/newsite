using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;
using static newsite.Services.PostData;

namespace newsite.Controllers;

using newsite.Services;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly EmployeeRepository _employeeRepo;

	public HomeController(ILogger<HomeController> logger, EmployeeRepository employeeRepo)
	{
		_logger = logger;
		_employeeRepo = employeeRepo;
	}

	public IActionResult Index()
	{

		ViewBag.Posts = PostData.GetPosts();
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
	
}
