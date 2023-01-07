using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.Models;
using Microsoft.EntityFrameworkCore;

namespace List10.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
