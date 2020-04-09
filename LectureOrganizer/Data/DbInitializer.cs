using System;
using System.Linq;
using LectureOrganizer.Data.Seeder;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LectureContext context)
        {
            context.Database.EnsureCreated();

            UserSeeder.Seed(context);
            LectureSeeder.Seed(context);
        }
    }
}
