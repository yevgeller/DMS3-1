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
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Students_List.TotalRecordsCount, PageSize));
        public string CurrentFilter { get; set; }
        public string CurrentParentFilter { get; set; }
        public Models.Student SelectedStudent { get; set; }
        //public List<Models.Person> Unselected_Parents { get; set; }
        public List<Models.Person_Student> Assigned_Parents { get; set; }
        public List<Models.Person> AllParents { get; set; }
        public string PagerInfo
        {
            get
            {
                return $"Page {Students_List.PageIndex} of {Students_List.TotalPages} ({Students_List.TotalRecordsCount} record{(Students_List.TotalRecordsCount > 1 ? "s" : "")})";
            }
        }
        public async Task<IActionResult> OnGetAsync(string currentFilter, string searchString, int? selectedStudent, int? pageIndex, string? parentFilter, int? id = 1)
        {
            await ResetPagePropertiesAsync(currentFilter, searchString, selectedStudent,
                pageIndex, parentFilter, id);
            return Page();
        }

        public async Task ResetPagePropertiesAsync(string currentFilter, string searchString,
            int? selectedStudent, int? pageIndex, string? parentFilter, int? id = 1)
        {
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
                SelectedStudent = await _context.Student
                    .Where(x => x.Student_Id == selectedStudent.Value)
                    .FirstOrDefaultAsync();

                Assigned_Parents = await _context.Parent_Student
                    .Where(x => x.Student_Id == SelectedStudent.Student_Id)
                    .Include(x => x.Person)
                    .ToListAsync();


                AllParents = await (from p in _context.Person
                                    join pt in _context.Person_Type
                                        on p.Person_Type_Id equals pt.Person_Type_Id
                                    where pt.Name.ToLower() == "parent" &&
                                        !(_context.Parent_Student.Any(x => x.Person_Id == p.Person_Id && x.Student_Id == SelectedStudent.Student_Id)) &&
                                        (String.IsNullOrWhiteSpace(parentFilter) || p.Name.Contains(parentFilter))
                                    select p)
                                   .OrderBy(x => x.Name)
                                   .ToListAsync();

                if (!String.IsNullOrWhiteSpace(parentFilter))
                {
                    CurrentParentFilter = parentFilter;
                }
            }

            CurrentFilter = searchString;
            IQueryable<Students_List> list = from s in _context.Students_List
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Student_Name.ToLower().Contains(searchString.ToLower()) ||
                                        s.AssignedToRooms.ToLower().Contains(searchString.ToLower()))
                    .OrderBy(x => x.Student_Name);
            }
            Students_List = await PaginatedList<Students_List>.CreateAsync(
                list.AsNoTracking(), pageIndex ?? 1, PageSize);

            Person_Student = await _context.Parent_Student
                .Include(p => p.Person)
                .Include(p => p.Student).FirstOrDefaultAsync(m => m.Person_Student_Id == id);

            ViewData["Person_Id"] = new SelectList(_context.Person, "Person_Id", "Name");
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Name");
        }

        public async Task<IActionResult> OnPostChangedParentFilterAsync(string currentFilter, string searchString, int? selectedStudent, int? pageIndex, string? parentFilter, int? id = 1)
        {
            await ResetPagePropertiesAsync(currentFilter, searchString, selectedStudent,
                pageIndex, parentFilter, id);
            return Page();
        }

        public void OnGetLalala()
        {
            var i = 1;
            i++;
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
