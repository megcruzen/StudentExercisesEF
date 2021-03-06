﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentExercisesEF.Data;
using StudentExercisesEF.Models;
using StudentExercisesEF.Models.ViewModels;

namespace StudentExercisesEF.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Instructor.Include(i => i.Cohort);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.Cohort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructors/Create
        public async Task<IActionResult> Create()
        {
            var cohorts = await _context.Cohort.ToListAsync();

            var viewModel = new InstructorCohortViewModel()
            {
                CohortOptions = new SelectList(_context.Cohort, "Id", "CohortName")
            };
            return View(viewModel);
        }

        // POST: Instructors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorCohortViewModel viewModel)
        {
            var instructor = viewModel.Instructor;

            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            viewModel = new InstructorCohortViewModel()
            {
                Instructor = instructor,
                CohortOptions = new SelectList(_context.Cohort, "Id", "CohortName", instructor.CohortId)
            };

            return View(viewModel);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            var cohorts = await _context.Cohort.ToListAsync();

            var viewModel = new InstructorCohortViewModel()
            {
                Instructor = instructor,
                CohortOptions = new SelectList(_context.Cohort, "Id", "CohortName", instructor.CohortId)
            };
            return View(viewModel);
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InstructorCohortViewModel viewModel)
        {
            var instructor = viewModel.Instructor;
            if (id != instructor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var cohorts = await _context.Cohort.ToListAsync();

            viewModel = new InstructorCohortViewModel()
            {
                Instructor = instructor,
                CohortOptions = new SelectList(_context.Cohort, "Id", "CohortName", instructor.CohortId)
            };
            return View(viewModel);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.Cohort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructor.FindAsync(id);
            _context.Instructor.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructor.Any(e => e.Id == id);
        }
    }
}
