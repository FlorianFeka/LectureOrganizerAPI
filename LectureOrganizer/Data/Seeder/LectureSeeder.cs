using System;
using System.Linq;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data.Seeder
{
    public static class LectureSeeder
    {
        public static void Seed(LectureContext context)
        {
            if (context.Lectures.Any())
            {
                return;
            }
            
            var unis = context.Unis.Select(x => x.UniId).ToArray();

            var lectures = new Lecture[]
            {
                new Lecture
                {
                    UniId = unis[0],
                    Name = "Infomatik 101",
                    Professor = "Proff Proff",
                    Rating = 4.6f,
                    Study = "Informatik",
                    Subject = "Informations Theorie",
                    Date = new DateTime()
                },
                new Lecture
                {
                    UniId = unis[1],
                    Name = "Algebra 101",
                    Professor = "Proff Soff",
                    Rating = 3.5f,
                    Study = "Mathematik",
                    Subject = "Mathematik",
                    Date = new DateTime()
                },
            };

            context.Lectures.AddRange(lectures);
            context.SaveChanges();
        }
    }
}