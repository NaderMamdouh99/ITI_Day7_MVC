using Day_8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Day_8.Pages.Company
{
    public class HomeModel : PageModel
    {
        public List<Instructor> Instructorss { get; set; } 

        private ItiContext context;
        public HomeModel(ItiContext _context)
        {
            context = _context;
        }

        public IActionResult OnGet()
        {
			Instructorss = context.Instructors.ToList();
            return Page();
        }
        public IActionResult OnPost(int? Id)
        {
            if(Id != null)
            {
                var found = context.Instructors.Find(Id);
                if (found != null)
                {
                    context.Instructors.Remove(found);
                    context.SaveChanges();
                    return RedirectToPage("Home");
                }
                return BadRequest();
            }
		    return RedirectToPage("Home");
		}
    }
}
