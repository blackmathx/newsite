using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;

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
        return View();
    }

    public IActionResult Employees()
    {
        var employees = _employeeRepo.GetAllEmployees();

        return View(employees);
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
