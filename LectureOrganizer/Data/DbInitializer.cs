using System;
using System.Linq;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LectureContext context)
        {
            context.Database.EnsureCreated();

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

            if (context.Lectures.Any())
            {
                return;
            }

            var lectures = new Lecture[]
            {
                new Lecture
                {
                    Name = "Infomatik 101",
                    Professor = "Proff Proff",
                    Study = "Informatik",
                    Subject = "Informations Theorie",
                    Date = new DateTime()
                },
                new Lecture
                {
                    Name = "Algebra 101",
                    Professor = "Proff Soff",
                    Study = "Mathematik",
                    Subject = "Mathematik",
                    Date = new DateTime()
                },
            };

            foreach (var lecture in lectures)
            {
                context.Lectures.Add(lecture);
            }
            context.SaveChanges();
        }
    }
}
