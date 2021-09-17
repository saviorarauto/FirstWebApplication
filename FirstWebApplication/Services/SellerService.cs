using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApplication.Data;
using FirstWebApplication.Models;
using FirstWebApplication.Services.Exceptions;
using Microsoft.EntityFrameworkCore; // Necessário para fazer o join de tabelas

namespace FirstWebApplication.Services
{
    public class SellerService
    {
        private readonly FirstWebApplicationContext _context;
        public SellerService(FirstWebApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() // era assim: public List<Seller> FindAll()
        {
            return await _context.Seller.Include(obj => obj.Department).Where(obj => obj.DepartmentId == obj.Department.Id ).ToListAsync();
        }

        public async Task InsertAsync(Seller obj) // era assim: public void Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); // era assim: _context.SaveChanges();
        }

        public async Task<Seller> FindByIdAsync(int id) // era assim: public Seller FindById(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        } 
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync (Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }

}
