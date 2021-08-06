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

        public string NameSort { get; set; }
        public string RoomSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
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

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            RoomSort = sortOrder == "Room" ? "room_desc" : "Room";

            //this.Count = await _context.Students_List.CountAsync();
            IQueryable<Students_List> list = from s in _context.Students_List
                                             select s;

            CurrentFilter = searchString;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Student_Name.ToLower().Contains(searchString.ToLower()) || 
                                        s.AssignedToRooms.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(s => s.Student_Name);
                    break;
                case "Room":
                    list = list.OrderBy(s => s.AssignedToRooms);
                    break;
                case "rooms_desc":
                    list = list.OrderByDescending(s => s.AssignedToRooms);
                    break;
                default:
                    list = list.OrderBy(s => s.Student_Name);
                    break;
            }

            Students_List = await list
                .AsNoTracking()
                .Skip((CurrentPage -1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            this.Count = await list.CountAsync();
            
            //Students_List = await studentService.GetPaginatedStudentListAsync(CurrentPage, PageSize, SortBy);
        }
    }
}
