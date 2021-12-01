using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBook.Models;

namespace CookBook.Infrastructure
{
    public class CookBookContext : DbContext
    {
        public CookBookContext(DbContextOptions<CookBookContext> options):base(options)
        {
        }
        public DbSet<CookBookList> CookBookList{ get; set; }
    }
}
