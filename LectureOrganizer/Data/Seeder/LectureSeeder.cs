using System;
using System.Collections.Generic;
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

            var lectures = new Lecture[]
            {
                new Lecture
                {
                    LectureId = 1,
                    Name = "Infomatik 101",
                    Professor = "Proff Proff",
                    Study = "Informatik",
                    Subject = "Informations Theorie",
                    Date = new DateTime()
                },
                new Lecture
                {
                    LectureId = 2,
                    Name = "Algebra 101",
                    Professor = "Proff Soff",
                    Study = "Mathematik",
                    Subject = "Mathematik",
                    Date = new DateTime()
                },
            };

            context.Lectures.AddRange(lectures);
        }
    }
}