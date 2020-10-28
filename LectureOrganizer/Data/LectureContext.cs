using LectureOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace LectureOrganizer.Data
{
    public class LectureContext : DbContext
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
