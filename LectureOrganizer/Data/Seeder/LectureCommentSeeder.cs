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
            if (context.LectureComment.Any())
            {
                return;
            }

            var lectureIds = context.Lecture.Select(x => x.LectureId).ToArray();
            var userIds = context.User.Select(x => x.UserId).ToArray();

            var lectureComments = new LectureComment[]
            {
                new LectureComment
                {
                    UserId = userIds[0],
                    LectureId = lectureIds[0],
                    Text = "Test comment1",
                    Date = DateTime.Now
                },
                new LectureComment
                {
                    UserId = userIds[1],
                    LectureId = lectureIds[0],
                    Text = "Test comment2",
                    Date = DateTime.Now
                },
                new LectureComment
                {
                    UserId = userIds[2],
                    LectureId = lectureIds[1],
                    Text = "Test comment3",
                    Date = DateTime.Now
                },
            };

            context.LectureComment.AddRange(lectureComments);
            context.SaveChanges();
        }
    }
}
