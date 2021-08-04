using System;
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
        private readonly IStudentData studentService;

        public IndexModel(DMS.Data.DMSDataContext context, IStudentData _studentService)
        {
            _context = context;
            studentService = _studentService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        
        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }
        public int Count { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<Models.Person> Data { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;

        public IList<Models.Students_List> Students_List { get; set; }

        public async Task OnGetAsync()
        {

            this.Count = await _context.Students_List.CountAsync();
            Students_List = await studentService.GetPaginatedStudentListAsync(CurrentPage, PageSize, SortBy);
            //Students_List = await _context.Students_List
            //    .OrderBy(d => d.Student_Id)
            //    .Skip((CurrentPage - 1) * PageSize)
            //    .Take(PageSize)
            //    .ToListAsync();
        }
    }
}
