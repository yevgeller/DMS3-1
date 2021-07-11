using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Contact_Type
{
    public class CreateModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public CreateModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Contact_Type Contact_Type { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contact_Type.Add(Contact_Type);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
