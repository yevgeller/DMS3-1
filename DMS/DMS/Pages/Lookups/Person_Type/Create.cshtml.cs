using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Lookups.Person_Type
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
        public Models.Person_Type Person_Type { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Person_Type.Add(Person_Type);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
