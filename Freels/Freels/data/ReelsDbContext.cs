using Freels.Modals.Reels;
using Microsoft.EntityFrameworkCore;

namespace Freels.data
{
    public class ReelsDbContext : DbContext
    {
        public ReelsDbContext(DbContextOptions<ReelsDbContext> options) : base(options)
        {
            
        }
        //Add-Migration MigrationReelsDbContext -Context ReelsDbContext
        //Update-Database -Context ReelsDbContext
        public DbSet<CommentsModal> commentsModals { get; set; }
        public DbSet<ReelsModal> reelsModals { get; set; }
        public DbSet<UserModal> usersModals { get; set; }
    }
}
