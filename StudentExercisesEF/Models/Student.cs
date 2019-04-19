using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentExercisesEF.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Student Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Slack { get; set; }

        [Required]
        [Display(Name = "Cohort")]
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
        
        public List<StudentExercise> StudentExercise {get; set;} = new List<StudentExercise>();
    }
}