using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentExercisesEF.Models
{
    public class Cohort
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        [Display(Name = "Cohort")]
        public string CohortName { get; set; }
        
        public List<Student> StudentList { get; set; } = new List<Student>();
        public List<Instructor> InstructorList { get; set; } = new List<Instructor>();
    }
}
