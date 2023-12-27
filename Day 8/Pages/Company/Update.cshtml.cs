using Day_8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Day_8.Pages.Company
{
    public class UpdateModel : PageModel
    {
        [BindProperty]  
        public Instructor Instructor { get; set; }
        private ItiContext Context;
        public UpdateModel(ItiContext _context)
        {
            Context = _context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                var found = Context.Instructors.Find(id);
                if (found != null)
                {
					ViewData["Department"] = new SelectList(Context.Departments.ToList(), "DeptId", "DeptName",found.InsId);
					Instructor = found;
                    return Page();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }
        public IActionResult OnPost()
        {
           var found = Context.Instructors.Where(I => I.InsId == Instructor.InsId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (found != null)
                {
                    found.InsName = Instructor.InsName;
                    found.InsDegree = Instructor.InsDegree;
                    found.DeptId = Instructor.DeptId;
                    found.Salary = Instructor.Salary;
                    Context.SaveChanges();
                    return RedirectToPage("Home");
                }
                else
                {
                    ViewData["Department"] = new SelectList(Context.Departments.ToList(), "DeptId", "DeptName", found?.InsId);
                    return Page();
                }
            }
			ViewData["Department"] = new SelectList(Context.Departments.ToList(), "DeptId", "DeptName", found?.InsId);
			return Page();
		}
    }
}
