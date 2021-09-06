﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstWebApplication.Models;

namespace FirstWebApplication.Data
{
    public class FirstWebApplicationContext : DbContext
    {
        public FirstWebApplicationContext (DbContextOptions<FirstWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FirstWebApplication.Models.Department> Department { get; set; }
    }
}
