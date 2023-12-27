using Day_8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day_8.Pages.Company
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Instructor Instructors { get; set; } 

        private ItiContext context;

        public CreateModel(ItiContext _context)
        {
            context = _context;
        }
        public IActionResult OnGet()
        {
            Instructors = new Instructor();
            ViewData["Department"] = new SelectList(context.Departments.ToList(), "DeptId", "DeptName");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.Instructors.Add(Instructors);
                    TempData["Alert"] = Instructors.InsName;
					context.SaveChanges();
                    return RedirectToPage("Home");
                }
                catch
                {
                    ModelState.AddModelError("Database Error", "Something went wrong in Database");
					ViewData["Department"] = new SelectList(context.Departments.ToList(), "DeptId", "DeptName");
                    return Page();
				}
			}
			ViewData["Department"] = new SelectList(context.Departments.ToList(), "DeptId", "DeptName");
			return Page();
		}
    }
}
