using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class CohortViewModel
    {
        public Cohort Cohort { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}
