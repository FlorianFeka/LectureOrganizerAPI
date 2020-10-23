using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureOrganizer.Models
{
    public class Lecture
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid LectureId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid UniId { get; set; }
        [Required]
        public string Study { get; set; }
        [Required]
        public string Subject { get; set; }
        [Column(TypeName = "TINYINT")]
        [Range(0, 5)]
        public float Rating { get; set; }
        public string Professor { get; set; }
        public DateTime Date { get; set; }

        public virtual Uni Unis { get; set; }
        public List<LectureComment> LectureComments { get; set; }
    }
}
