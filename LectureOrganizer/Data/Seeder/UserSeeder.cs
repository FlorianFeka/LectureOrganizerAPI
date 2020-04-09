using LectureOrganizer.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace LectureOrganizer.Data.Seeder
{
    public static class UserSeeder
    {
        public static void Seed(LectureContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{ Username = "MaxMuster", Email = "maxmuster@gmail.com", Password = "password" },
                new User{ Username = "Lystus", Email = "lystus@gmail.com", Password = "password" },
                new User{ Username = "FreshSlash", Email = "freshslash@gmail.com", Password = "password" },
                new User{ Username = "ElDiabolo", Email = "eldiabolo@gmail.com", Password = "password" }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}