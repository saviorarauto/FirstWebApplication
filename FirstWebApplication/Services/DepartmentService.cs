using FirstWebApplication.Data;
using FirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.Services
{
    public class DepartmentService
    {
        private readonly FirstWebApplicationContext _context;
        public DepartmentService(FirstWebApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() // Antes era assim: public List<Department> FindAll()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); // era assim: return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
