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

		public List<Submission> GetAllSubmissions()
		{
			return _context.Submissions
				.Where(s => s.Active)
				.OrderByDescending(s => s.CreatedAt)
				.ToList();
		}

		public async Task RemoveSubmission(int id)
		{
			Submission? submission = await _context.Submissions.FirstOrDefaultAsync(s => s.Id == id);
			if (submission != null)
			{
				submission.Active = false;
				_context.Update(submission);
				await _context.SaveChangesAsync();
			}
		}

	  }


}