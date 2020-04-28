using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureOrganizer.Models
{
    public class LectureComment
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid LectureCommentId { get; set; } = Guid.NewGuid();
        [Required]
        public string Text { get; set; }
        public Guid LectureId { get; set; }
        public Guid UserId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual User User { get; set; }
    }
}