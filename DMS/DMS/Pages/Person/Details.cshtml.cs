using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace DMS.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public DetailsModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public Models.Person Person { get; set; }
        public List<PersonnelContact_List> Contacts { get; set; }
        public int SelectedContactTypeId { get; set; }
        public List<SelectListItem> Contact_Types { get; set; }
        [BindProperty(SupportsGet =true)]
        public string NewContactValue { get; set; }
        public string NewEmailValue { get; set; }
        public string NewPhoneVoiceTextValue { get; set; }
        public string NewPhoneVoiceValue { get; set; }
        public string NewPhoneTextValue { get; set; }

        public async Task<IActionResult> OnGetAsync(int selectedContactTypeId, string newContactValue, int? id)
        {
            return await ProcessPage(selectedContactTypeId, newContactValue, id);
        }

        public async Task<IActionResult> OnPostAddNewContactAsync(int selectedContactTypeId, string newContactValue, int? id)
        {
            return await ProcessPage(selectedContactTypeId, newContactValue, id);
        }

        public async Task<IActionResult> ProcessPage(int selectedContactTypeId, string newContactValue, int? id)
        {

            var contactType = await _context.Contact_Type.FirstOrDefaultAsync(x => x.Contact_Type_Id == selectedContactTypeId);
            if (contactType != null && string.IsNullOrEmpty(newContactValue))
            {
                ModelState.AddModelError("NewContactValue", $"Enter new {contactType.Name}");
            }
            if (!string.IsNullOrEmpty(newContactValue))
            {
                if (contactType != null && contactType.Name.ToLower().StartsWith("email") &&
                    !Regex.IsMatch(newContactValue,
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    ModelState.AddModelError("NewContactValue", "Invalid e-mail");
                }

                if (contactType != null && contactType.Name.ToLower().StartsWith("phone") &&
                    !Regex.IsMatch(newContactValue, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    ModelState.AddModelError("NewContactValue", "Invalid phone");
                }
            }
            if (!ModelState.IsValid) //TODO: Figure out model binding
            {
                Person = await _context.Person
                    .Include(p => p.Person_Type).FirstOrDefaultAsync(m => m.Person_Id == id);
                Contacts = await _context.PersonnelContact_List.Where(x => x.Person_Id == id).ToListAsync();
                Contact_Types = await _context.Contact_Type.Select(i =>
                           new SelectListItem
                           {
                               Value = i.Contact_Type_Id.ToString(),
                               Text = i.Name
                           }).ToListAsync();
                return Page();
            }


            if (id == null)
            {
                return NotFound();
            }
            //test this, 
            //    add front-end validation just like on Edit Contact
            Person = await _context.Person
                .Include(p => p.Person_Type).FirstOrDefaultAsync(m => m.Person_Id == id);


            if (Person == null)
            {
                return NotFound();
            }

            Contacts = await _context.PersonnelContact_List.Where(x => x.Person_Id == id).ToListAsync();
            Contact_Types = await _context.Contact_Type.Select(i =>
                       new SelectListItem
                       {
                           Value = i.Contact_Type_Id.ToString(),
                           Text = i.Name
                       }).ToListAsync();

            return Page();
        }
    }
}
