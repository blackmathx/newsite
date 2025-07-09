using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newsite.Models;
using newsite.Services;

namespace NewSite.Controllers;

public class AdminController : Controller
{
	private readonly ILogger<AdminController> _logger;
	private readonly PostRepository _postRepository;
	private readonly SubmissionRepository _submissionRepository;

	public AdminController(
		ILogger<AdminController> logger,
		PostRepository postRepository,
		SubmissionRepository submissionRepository
		)
	{
		_logger = logger;
		_postRepository = postRepository;
		_submissionRepository = submissionRepository;
	}

	public IActionResult Index()
	{
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
		post.CreatedAt = DateTime.UtcNow.AddHours(-5);
		post.Active = false;
		_postRepository.AddPost(post);
		_postRepository.SaveChanges();
		return RedirectToAction("Index");
	}

	[HttpGet]
	public IActionResult PublishPost(int id)
	{
		var post = _postRepository.GetPostById(id);
		if (post == null)
		{
			return NotFound();
		}
		post.Active = true;
		post.CreatedAt = DateTime.UtcNow.AddHours(-5); // Convert to EST
		_postRepository.UpdatePost(post);
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
		return RedirectToAction("DraftPosts");
	}

	[HttpGet]
	public IActionResult CreatePost()
	{
		return View();
	}


	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult CreatePost(Post post)
	{
		if (!ModelState.IsValid)
		{
			return View(post);
		}
		// Convert UTC to EST (UTC-5) for posting date
		post.CreatedAt = DateTime.UtcNow.AddHours(-5);
		post.Active = false;
		_postRepository.AddPost(post);
		_postRepository.SaveChanges();
		return RedirectToAction("Index");
	}

	[HttpGet]
	public IActionResult Submissions()
	{
		var submissions = _submissionRepository.GetAllSubmissions();
		ViewBag.Submissions = submissions;
		return View();
	}

	[HttpGet]
	public IActionResult SubmissionDetail(int id)
	{
		var submission = _submissionRepository.GetSubmissionById(id);
		if (submission == null)
		{
			return NotFound();
		}
		ViewBag.Submission = submission;
		return View();
	}

	[HttpGet]
	public IActionResult DeleteSubmission(int id)
	{
		_submissionRepository.RemoveSubmission(id);
		return RedirectToAction("Submissions");
	}

	[HttpGet]
	public IActionResult SubmissionConvertToDraft(int id)
	{
		var submission = _submissionRepository.GetSubmissionById(id);
		if (submission == null)
		{
			return NotFound();
		}

		var post = new Post
		{
			Title = submission.Title,
			Url = submission.Url,
			CreatedAt = DateTime.UtcNow.AddHours(-5), // Convert to EST
			Active = false
		};

		_postRepository.AddPost(post);
		_postRepository.SaveChanges();

		return RedirectToAction("Index");
	}


	[HttpGet]
	public async Task<IActionResult> DraftPosts()
	{
		ViewBag.Posts = await _postRepository.GetDraftPosts();
		return View();
	}

}