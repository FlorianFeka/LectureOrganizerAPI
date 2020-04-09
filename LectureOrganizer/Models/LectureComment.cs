using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureOrganizer.Models
{
    public class LectureComment
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Text { get; set; }
        public int LectureId { get; set; }
        public int UserId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual User User { get; set; }
    }
}