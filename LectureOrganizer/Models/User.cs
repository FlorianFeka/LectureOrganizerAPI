﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LectureOrganizer.Models
{
    public class User
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
