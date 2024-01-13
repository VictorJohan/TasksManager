using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksManager.Models;

namespace TasksManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}