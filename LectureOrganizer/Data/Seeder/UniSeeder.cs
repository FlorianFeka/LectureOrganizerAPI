using System.Linq;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data.Seeder
{
    public class UniSeeder
    {
         public static void Seed(LectureContext context)
         {
             if (context.Unis.Any())
             {
                 return;
             }

             var unis = new []
             {
                 new Uni
                 {
                     Name = "TU Wien"
                 },
                 new Uni
                 {
                     Name = "Uni Wien"
                 },
             };

             context.Unis.AddRange(unis);
             context.SaveChanges();
         }
    }
}