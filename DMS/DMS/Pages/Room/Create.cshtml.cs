using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Room
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
            ViewData["Age_Bracket_Id"] = new SelectList(_context.Age_Bracket, "Age_Bracket_Id", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Room Room { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Room.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
