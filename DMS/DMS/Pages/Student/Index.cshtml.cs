﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public IndexModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public IList<Models.Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
