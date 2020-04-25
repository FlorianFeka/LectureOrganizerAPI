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

            var lectureComments = new LectureComment[]
            {
                new LectureComment
                {
                    LectureCommentId = 1,
                    UserId = 1,
                    LectureId = 1,
                    Text = "Test comment"
                },
                new LectureComment
                {
                    LectureCommentId = 2,
                    UserId = 3,
                    LectureId = 1,
                    Text = "Test comment"
                },
                new LectureComment
                {
                    LectureCommentId = 3,
                    UserId = 2,
                    LectureId = 2,
                    Text = "Test comment"
                },
            };

            context.LectureComments.AddRange(lectureComments);
        }
    }
}
