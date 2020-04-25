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
                new User{ UserId = 1, Username = "MaxMuster", Email = "maxmuster@gmail.com", Password = "password" },
                new User{ UserId = 2, Username = "Lystus", Email = "lystus@gmail.com", Password = "password" },
                new User{ UserId = 3, Username = "FreshSlash", Email = "freshslash@gmail.com", Password = "password" },
                new User{ UserId = 4, Username = "ElDiabolo", Email = "eldiabolo@gmail.com", Password = "password" }
            };

            context.Users.AddRange(users);
        }
    }
}