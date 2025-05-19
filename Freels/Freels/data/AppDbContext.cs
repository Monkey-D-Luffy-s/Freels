using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freels.data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ReaderRoleId = "191bd90a-c5c6-43a1-8432-b2d2cc13840c";
            var WriterRoleId = "8ce20a03-596a-422a-a06d-0ff5187ab36f";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    ConcurrencyStamp = ReaderRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = WriterRoleId,
                    ConcurrencyStamp = WriterRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
