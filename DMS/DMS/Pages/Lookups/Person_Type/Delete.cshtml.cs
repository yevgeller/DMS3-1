using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Person_Type
{
    public class DeleteModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DeleteModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Person_Type Person_Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person_Type = await _context.Person_Type.FirstOrDefaultAsync(m => m.Person_Type_Id == id);

            if (Person_Type == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person_Type = await _context.Person_Type.FindAsync(id);

            if (Person_Type != null)
            {
                _context.Person_Type.Remove(Person_Type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
