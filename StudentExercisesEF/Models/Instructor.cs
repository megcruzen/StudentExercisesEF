using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudentExercisesEF.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display(Name = "Instructor Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Slack { get; set; }
        
        [Required]
        [Display(Name = "Cohort")]
        public int CohortId { get; set; }
        public Cohort Cohort { get; set; }
    }
}
