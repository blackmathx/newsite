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
      }


}