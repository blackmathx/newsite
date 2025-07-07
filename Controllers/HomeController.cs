using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;

namespace newsite.Controllers;

using newsite.Services;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly PostRepository _postRepository;

	public HomeController(ILogger<HomeController> logger, PostRepository postRepository)
	{
		_logger = logger;
		_postRepository = postRepository;
	}

	public IActionResult Index()
	{
		ViewBag.Posts = _postRepository.GetAllPosts();
		return View();
	}


	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}

	[HttpGet]
	public IActionResult SubmitPost()
	{
		return View();
	}
	[HttpPost]
	public IActionResult SubmitPost(Post post)
	{
		// Convert UTC to EST (UTC-5) for posting date
		post.PostedOn = DateTime.UtcNow.AddHours(-5);
		post.Active = false;
		_postRepository.AddPost(post);
		_postRepository.SaveChanges();
		return RedirectToAction("Index");
	}

	public IActionResult Donate()
	{
		return View();
	}
	
}
