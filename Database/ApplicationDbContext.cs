using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using the_other_balloon_widget.Models;

namespace the_other_balloon_widget.Database
{
    public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
         protected override void OnModelCreating(ModelBuilder modelBuilder){}

         public DbSet<Colors> Colors { get; set; }
    }
}