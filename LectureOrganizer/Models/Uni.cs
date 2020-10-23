using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LectureOrganizer.Models
{
    public class Uni
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UniId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
    }
}