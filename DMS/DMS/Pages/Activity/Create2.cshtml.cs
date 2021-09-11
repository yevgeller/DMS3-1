using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DMS.Pages.Activity
{
    public class Create2Model : PageModel
    {
        private readonly DMSDataContext db;

        public Create2Model(DMSDataContext _db)
        {
            this.db = _db;
        }
        [BindProperty]
        public Models.Student Student { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Date { get; set; }
        [BindProperty]
        public string Time { get; set; }
        [BindProperty]
        public List<string> Activity_Groups { get; private set; }

        [BindProperty]
        public string Activity_TimeStamp { get; set; }

        public List<Models.Activity_Type> Activity_Types { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            Student = await db.Student.Where(x => x.Student_Id == id).FirstOrDefaultAsync();
            Activity_TimeStamp = DateTime.Now.ToString("ddd, MMMM dd, yyyy");
            //Date = DateTime.Now.ToShortDateString();
            //Time = DateTime.Now.ToShortTimeString();
            Activity_Types = await db.Activity_Type
                .OrderBy(x => x.SortOrder)
                .ThenBy(x => x.Name)
                .ToListAsync();

            Activity_Groups = Activity_Types
                .Select(x => x.GroupingString)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
            return Page();
        }

        public void OnPost()
        {
            var a = this.Date;
            var b = this.Student;
            var c = Time;
            int i = 0;
        }
    }
}
