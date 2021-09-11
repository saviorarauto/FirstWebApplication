﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApplication.Data;
using FirstWebApplication.Models;

namespace FirstWebApplication.Services
{
    public class SellerService
    {
        private readonly FirstWebApplicationContext _context;
        public SellerService(FirstWebApplicationContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }

}