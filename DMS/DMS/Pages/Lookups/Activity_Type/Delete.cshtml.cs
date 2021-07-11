using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Activity_Type
{
    public class DeleteModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DeleteModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Activity_Type Activity_Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity_Type = await _context.Activity_Type.FirstOrDefaultAsync(m => m.Activity_Type_Id == id);

            if (Activity_Type == null)
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

            Activity_Type = await _context.Activity_Type.FindAsync(id);

            if (Activity_Type != null)
            {
                _context.Activity_Type.Remove(Activity_Type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
