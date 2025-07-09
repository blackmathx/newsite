using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using newsite;
using newsite.Models;

namespace newsite.Services
{
	public class PostRepository
	{
		private readonly AppDbContext _context;

		public PostRepository(AppDbContext context)
		{
			_context = context;
		}

		public List<Post> GetAllPosts()
		{
			return _context.Posts.ToList();
		}

		public async Task<List<Post>> GetActivePosts()
		{
			return await _context.Posts
				.AsNoTracking()
				.Where(post => post.Active)
				.ToListAsync();
		}

		public void AddPost(Post post)
		{
			_context.Posts.Add(post);
		}

		public Post? GetPostById(int id)
		{
			return _context.Posts.FirstOrDefault(p => p.Id == id);
		}

		public void DeletePost(int id)
		{
			var post = GetPostById(id);
			if (post == null) return;

			_context.Posts.Remove(post);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public async Task<List<Post>> GetDraftPosts()
		{
			return await _context.Posts
				.AsNoTracking()
				.Where(post => !post.Active)
				.ToListAsync();
		}

		public void UpdatePost(Post post)
		{
			_context.Posts.Update(post);
			_context.SaveChanges();
		}
	}
}