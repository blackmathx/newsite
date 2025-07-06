using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NewSite.Controllers;

public class AdminController : Controller
{
	private readonly ILogger<AdminController> _logger;

	public AdminController(ILogger<AdminController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		Console.WriteLine("AdminController Index action called");
		return View();
	}

}