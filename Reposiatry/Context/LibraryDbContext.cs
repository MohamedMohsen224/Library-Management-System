using Core.Entities;
using Core.IdentityServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiatry.Context
{
    public class LibraryDbContext : IdentityDbContext<AppUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet <Borrowing_Record> Borrowing_Records { get; set; }
        
    }
}
