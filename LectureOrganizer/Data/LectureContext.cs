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
    }
}
