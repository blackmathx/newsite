
using System.Collections.Generic;
using System.Linq;
using newsite;
using newsite.Models;

namespace newsite.Services
{
    public class EmployeeRepo
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
