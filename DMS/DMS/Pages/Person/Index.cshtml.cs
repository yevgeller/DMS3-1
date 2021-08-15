using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public IndexModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public IList<Models.Person> Person { get;set; }
        public IList<Models.Persons_List> Persons_List { get; set; }
        public async Task OnGetAsync()
        {
            Person = await _context.Person
                .Include(p => p.Person_Type).ToListAsync();
            Persons_List = await _context.Persons_List.ToListAsync();
        }
    }
}
