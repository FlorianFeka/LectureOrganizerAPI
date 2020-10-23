using LectureOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace LectureOrganizer.Data
{
    public class LectureContext : DbContext
    {
        public LectureContext(DbContextOptions<LectureContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureComment> LectureComments { get; set; }
        public DbSet<Uni> Unis { get; set; }
    }
}
