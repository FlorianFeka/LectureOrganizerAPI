using LectureOrganizer.Models;
using LectureOrganizer.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LectureOrganizer.Data
{
    public class LectureContext : IdentityDbContext<ApplicationUser>
    {
        public LectureContext(DbContextOptions<LectureContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Lecture> Lecture { get; set; }
        public DbSet<LectureComment> LectureComment { get; set; }
        public DbSet<Uni> Uni { get; set; }
    }
}
