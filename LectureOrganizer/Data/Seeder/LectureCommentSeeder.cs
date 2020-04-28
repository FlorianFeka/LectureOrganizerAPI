using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LectureOrganizer.Models;

namespace LectureOrganizer.Data.Seeder
{
    public class LectureCommentSeeder
    {
        public static void Seed(LectureContext context)
        {
            if (context.LectureComments.Any())
            {
                return;
            }

            var lectureIds = context.Lectures.Select(x => x.LectureId).ToArray();
            var userIds = context.Users.Select(x => x.UserId).ToArray();

            var lectureComments = new LectureComment[]
            {
                new LectureComment
                {
                    UserId = userIds[0],
                    LectureId = lectureIds[0],
                    Text = "Test comment"
                },
                new LectureComment
                {
                    UserId = userIds[1],
                    LectureId = lectureIds[0],
                    Text = "Test comment"
                },
                new LectureComment
                {
                    UserId = userIds[2],
                    LectureId = lectureIds[1],
                    Text = "Test comment"
                },
            };

            context.LectureComments.AddRange(lectureComments);
            context.SaveChanges();
        }
    }
}
