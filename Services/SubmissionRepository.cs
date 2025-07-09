using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using newsite;
using newsite.Models;

namespace newsite.Services
{
	public class SubmissionRepository
	{
		private readonly AppDbContext _context;

		public SubmissionRepository(AppDbContext context)
		{
			_context = context;
		}

		public void AddSubmission(Submission submission)
		{
			_context.Submissions.Add(submission);
			_context.SaveChanges();
		}

		public List<Submission> GetAllSubmissions()
		{
			return _context.Submissions
				.Where(s => s.Active)
				.OrderByDescending(s => s.CreatedAt)
				.ToList();
		}

		public void RemoveSubmission(int id)
		{
			Submission? submission = _context.Submissions.FirstOrDefault(s => s.Id == id);
			if (submission != null)
			{
				submission.Active = false;
				_context.Update(submission);
				_context.SaveChanges();
			}
		}

		public Submission? GetSubmissionById(int id)
		{
			return _context.Submissions.FirstOrDefault(s => s.Id == id);
		}

	  }


}