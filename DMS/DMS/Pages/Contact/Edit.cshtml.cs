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

namespace DMS.Pages.Contact
{
    public class EditModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public EditModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact
                .Include(c => c.Contact_Type)
                .Include(c => c.Person).FirstOrDefaultAsync(m => m.Contact_Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            ViewData["Contact_Type_Id"] = new SelectList(_context.Contact_Type, "Contact_Type_Id", "Name");
            ViewData["Person_Id"] = new SelectList(_context.Person, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var c = await _context.Contact.FirstOrDefaultAsync(x => x.Contact_Id == id);

            if (c == null)
            {
                return NotFound();
            }

            c.Contact_Type_Id = Contact.Contact_Type_Id;
            c.Value = Contact.Value;
            _context.Attach(c).State = EntityState.Modified;
            //_context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(c.Contact_Id))
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

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Contact_Id == id);
        }
    }
}
