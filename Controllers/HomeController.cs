using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;

namespace newsite.Controllers;

using newsite.Services;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EmployeeRepo _employeeRepo;

    public HomeController(ILogger<HomeController> logger, EmployeeRepo employeeRepo)
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
        // foreach (var emp in employees)
        // {
        //     Console.WriteLine($"Id: {emp.Id}, Name: {emp.FirstName} {emp.LastName}, Salary: {emp.Salary}, Description: {emp.Description}");
        // }
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
