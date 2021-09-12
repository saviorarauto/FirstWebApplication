using FirstWebApplication.Data;
using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Services
{
    public class DepartmentService
    {
        private readonly FirstWebApplicationContext _context;
        public DepartmentService(FirstWebApplicationContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
