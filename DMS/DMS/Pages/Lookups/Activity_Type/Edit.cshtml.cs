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

namespace DMS.Pages.Lookups.Activity_Type
{
    public class EditModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public EditModel(DMS.Data.DMSDataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Activity_Type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Activity_TypeExists(Activity_Type.Activity_Type_Id))
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

        private bool Activity_TypeExists(int id)
        {
            return _context.Activity_Type.Any(e => e.Activity_Type_Id == id);
        }
    }
}
