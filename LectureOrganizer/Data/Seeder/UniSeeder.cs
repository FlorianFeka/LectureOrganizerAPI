using System.Linq;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data.Seeder
{
    public class UniSeeder
    {
         public static void Seed(LectureContext context)
         {
             if (context.Uni.Any())
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

             context.Uni.AddRange(unis);
             context.SaveChanges();
         }
    }
}