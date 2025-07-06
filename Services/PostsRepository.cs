using System.Collections.Generic;
using System.Linq;
using newsite;
using newsite.Models;

namespace newsite.Services
{
    public class PostsRepository
    {
        private readonly AppDbContext _context;

        public PostsRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }


    }
}