using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using newsite;
using newsite.Models;

namespace newsite.Services
{
      public class UserCommentRepository
      {
            private readonly AppDbContext _context;

            public UserCommentRepository(AppDbContext context)
            {
                  _context = context;
            }

            // public List<Comment> GetAllComments()
            // {
            //       return _context.Comments.ToList();
            // }
      }
}