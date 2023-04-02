using EVProjectDup.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EVProjectDup.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }

        public DbSet<Station> stations { get; set; }

        public DbSet<Booking> bookings { get; set; }

        
    }
}
