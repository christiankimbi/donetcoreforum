
using LambdaForums.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LambdaForums.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<ApplicationUser> ApplicationUses {get; set;}
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Pots { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
    }
}

