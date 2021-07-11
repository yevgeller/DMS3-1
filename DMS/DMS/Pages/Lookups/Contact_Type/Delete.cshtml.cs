using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Contact_Type
{
    public class DeleteModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DeleteModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Contact_Type Contact_Type { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact_Type = await _context.Contact_Type.FirstOrDefaultAsync(m => m.Contact_Type_Id == id);

            if (Contact_Type == null)
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

            Contact_Type = await _context.Contact_Type.FindAsync(id);

            if (Contact_Type != null)
            {
                _context.Contact_Type.Remove(Contact_Type);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
