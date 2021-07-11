using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Age_Bracket
{
    public class DeleteModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DeleteModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Age_Bracket Age_Bracket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Age_Bracket = await _context.Age_Bracket.FirstOrDefaultAsync(m => m.Age_Bracket_Id == id);

            if (Age_Bracket == null)
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

            Age_Bracket = await _context.Age_Bracket.FindAsync(id);

            if (Age_Bracket != null)
            {
                _context.Age_Bracket.Remove(Age_Bracket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
