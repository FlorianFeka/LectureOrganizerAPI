using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureOrganizer.Models
{
    public class Lecture
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Study { get; set; }
        public string Professor { get; set; }
        public DateTime Date { get; set; }
    }
}
