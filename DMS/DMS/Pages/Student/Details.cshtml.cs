using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DetailsModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public Models.Student Student { get; set; }
        public List<Models.Person> Guardians { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.Student_Id == id);
            Guardians = await _context.Parent_Student
                .Where(x => x.Student_Id == id)
                .Include(x => x.Person)
                .Select(x => x.Person)
                .ToListAsync();

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
