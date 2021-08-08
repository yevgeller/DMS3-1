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
        public PaginatedList<Students_List> Students_List { get; set; }
        public int PageSize { get; set; } = 10;
        public int Count { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public string CurrentFilter { get; set; }
        public int SelectedStudent { get; set; }
        public string PagerInfo
        {
            get
            {
                return $"Page {Students_List.PageIndex} of {TotalPages} ({this.Count} record{(this.Count > 1 ? "s" : "")})";
            }
        }
        public async Task<IActionResult> OnGetAsync(string currentFilter, string searchString, int? selectedStudent, int? pageIndex, int? id = 1)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (selectedStudent.HasValue)
            {
                SelectedStudent = selectedStudent.Value;
            }

            CurrentFilter = searchString;
            IQueryable<Students_List> list = from s in _context.Students_List
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Student_Name.ToLower().Contains(searchString.ToLower()) ||
                                        s.AssignedToRooms.ToLower().Contains(searchString.ToLower()));
            }
            Students_List = await PaginatedList<Students_List>.CreateAsync(
                list.AsNoTracking(), pageIndex ?? 1, PageSize);

            Person_Student = await _context.Parent_Student
                .Include(p => p.Person)
                .Include(p => p.Student).FirstOrDefaultAsync(m => m.Person_Student_Id == id);


            //if (Person_Student == null)
            //{
            //    return NotFound();
            //}
            ViewData["Person_Id"] = new SelectList(_context.Person, "Person_Id", "Name");
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Name");
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
