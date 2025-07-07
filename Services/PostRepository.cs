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

        public List<Post> GetAllActivePosts(){
            return _context.Posts.ToList();
        }

        public void AddPost(Post post)
        {                                       
            _context.Posts.Add(post);
        }

        public Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void DeletePost(int id)
        {
            var post = GetPostById(id);
            _context.Posts.Remove(post);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}