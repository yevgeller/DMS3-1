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
            if (id == null)
            {
                return NotFound();
            }

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

            //Options = context.Authors.Select(a =>
            //                      new SelectListItem
            //                      {
            //                          Value = a.AuthorId.ToString(),
            //                          Text = a.Name
            //                      }).ToList();
            return Page();
        }
    }
}
