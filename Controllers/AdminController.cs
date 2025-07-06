using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newsite.Models;
using newsite.Services;

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

	[Route("Admin/Post/{id}")]
	public IActionResult Detail(int id)
	{
		Post? post = PostData.GetPosts().FirstOrDefault(p => p.Id == id);
		ViewBag.Post = post;
		return View("~/Views/Admin/Post/Detail.cshtml");
	}

	[HttpGet]
	[Route("Admin/Post/Add")]
	public IActionResult Add()
	{
		return View("~/Views/Admin/Post/Add.cshtml");
	}

	[HttpPost]
	[Route("Admin/Post/Add")]
	[ValidateAntiForgeryToken]
	public IActionResult Add(Post post)
	{
		if (!ModelState.IsValid)
		{
			return View(post);
		}
		Console.WriteLine($"Adding post: {post.Title}, URL: {post.Url}, PostedOn: {DateTime.Now}");
		// Todo: add a method to PostsRepository to save the post
		// _postsRepository.AddPost(post);

		return RedirectToAction("Index");
	}


	[HttpGet]
	[Route("Admin/Post/Edit/{id}")]
	public IActionResult Edit(int id)
	{
		// For demonstration, you should fetch from repo. Here, just a sample:
		var post = PostData.GetPosts().FirstOrDefault(p => p.Id == id);
		return View("~/Views/Admin/Post/Edit.cshtml");
	}

	[HttpPost]
	[Route("Admin/Post/Edit/{id}")]
	[ValidateAntiForgeryToken]
	public IActionResult Edit(int id, Post post)
	{
		if (id != post.Id)
			return BadRequest();
		if (!ModelState.IsValid)
			return View(post);
		// You should add an Update method to PostsRepository for real use
		// For now, just a placeholder
		// _postsRepository.UpdatePost(post);
		return RedirectToAction("Index");
	}
}