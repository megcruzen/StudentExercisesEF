using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentExercisesEF.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        public string ExerciseName { get; set; }

        [Required]
        public string ExerciseLanguage { get; set; }

        public List<StudentExercise> StudentExercise { get; set; } = new List<StudentExercise>();
    }
}
