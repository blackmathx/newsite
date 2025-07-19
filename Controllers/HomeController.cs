using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using newsite.Models;
using newsite.Services;

namespace newsite.Controllers;


public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly PostRepository _postRepository;
	private readonly SubmissionRepository _submissionRepository;

	public HomeController(
		ILogger<HomeController> logger,
		PostRepository postRepository,
		SubmissionRepository submissionRepository
		)
	{
		_logger = logger;
		_postRepository = postRepository;
		_submissionRepository = submissionRepository;
	}

	public async Task<IActionResult> Index()
	{
		ViewBag.Posts = await _postRepository.GetActivePosts();
		return View();
	}

	[HttpGet]
	public IActionResult SubmitArticle()
	{
		return View();
	}

	[HttpPost]
	public IActionResult SubmitArticle(Submission submission)
	{
		// Convert UTC to EST (UTC-5) for posting date
		submission.CreatedAt = DateTime.UtcNow.AddHours(-5);
		submission.Active = true;

		_submissionRepository.AddSubmission(submission);

		return View("SubmitArticleSuccess");
	}

	public IActionResult Donate()
	{
		return View();
	}



	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}

	[HttpGet]
	public IActionResult Post(int id)
	{
		
		var post = _postRepository.GetPostById(id);
		if (post == null)
		{
			return NotFound();
		}

		ViewBag.Post = post;
		return View();
	}

	
}
