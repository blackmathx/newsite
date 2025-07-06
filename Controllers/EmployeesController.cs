using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;

namespace newsite.Controllers;

using newsite.Services;

public class EmployeesController : Controller
{
	private readonly ILogger<EmployeesController> _logger;
	private readonly EmployeeRepository _employeeRepo;

	public EmployeesController(ILogger<EmployeesController> logger, EmployeeRepository employeeRepo)
	{
		_logger = logger;
		_employeeRepo = employeeRepo;
	}

	public IActionResult Index()
	{
		var employees = _employeeRepo.GetAllEmployees();

		return View(employees);
	}


}