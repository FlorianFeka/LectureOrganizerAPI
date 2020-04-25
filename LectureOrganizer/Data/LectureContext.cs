using LectureOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace LectureOrganizer.Data
{
    public class LectureContext : DbContext
    {
        public LectureContext(DbContextOptions<LectureContext> options) : base(options)
        {

        }

        /*        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<User>()
                        .Property(u => u.Username);
                }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<LectureComment> LectureComments { get; set; }
    }
}
