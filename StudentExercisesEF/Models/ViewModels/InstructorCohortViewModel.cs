using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesEF.Models.ViewModels
{
    public class InstructorCohortViewModel
    {
        public Instructor Instructor { get; set; }
        public SelectList CohortOptions { get; set; }
    }
}
