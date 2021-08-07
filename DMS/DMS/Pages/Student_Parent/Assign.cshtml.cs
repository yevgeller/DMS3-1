using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Student_Parent
{
    public class AssignModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public AssignModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person_Student Person_Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person_Student = await _context.Parent_Student
                .Include(p => p.Person)
                .Include(p => p.Student).FirstOrDefaultAsync(m => m.Person_Student_Id == id);

            if (Person_Student == null)
            {
                return NotFound();
            }
           ViewData["Person_Id"] = new SelectList(_context.Person, "Person_Id", "Name");
           ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Student_Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person_Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Person_StudentExists(Person_Student.Person_Student_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Person_StudentExists(int id)
        {
            return _context.Parent_Student.Any(e => e.Person_Student_Id == id);
        }
    }
}
