using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newsite.Models;
using newsite.Services;

namespace NewSite.Controllers;

public class AdminController : Controller
{
	private readonly ILogger<AdminController> _logger;
	private readonly PostRepository _postRepository;

	public AdminController(ILogger<AdminController> logger, PostRepository postRepository)
	{
		_logger = logger;
		_postRepository = postRepository;
	}

	public IActionResult Index()
	{
		ViewBag.Posts = _postRepository.GetAllPosts();
		return View();
	}

	public IActionResult PostDetail(int id)
	{
		Post? post = _postRepository.GetPostById(id);
		ViewBag.Post = post;
		return View();
	}

	[HttpGet]
	public IActionResult PostAdd()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult PostAdd(Post post)
	{
		if (!ModelState.IsValid)
		{
			return View(post);
		}

		// Convert UTC to EST (UTC-5) for posting date
		post.PostedOn = DateTime.UtcNow.AddHours(-5);
		post.Active = true;
		_postRepository.AddPost(post);
		_postRepository.SaveChanges();

		return RedirectToAction("Index");
	}


	[HttpGet]
	public IActionResult PostEdit(int id)
	{
		// For demonstration, you should fetch from repo. Here, just a sample:
		var post = _postRepository.GetPostById(id);
		ViewBag.Post = post;
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult PostEdit(int id, Post post)
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

	[HttpGet]
	public IActionResult PostDelete(int id)
	{
		_postRepository.DeletePost(id);
		_postRepository.SaveChanges();
		return RedirectToAction("Index");	
	}
	
	
}