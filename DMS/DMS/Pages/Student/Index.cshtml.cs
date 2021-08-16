using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;
        private readonly IStudentData studentService;
        private readonly IConfiguration Configuration;
        public IndexModel(DMS.Data.DMSDataContext context, IStudentData _studentService, IConfiguration _configuration)
        {
            _context = context;
            studentService = _studentService;
            Configuration = _configuration;
        }

        //[BindProperty(SupportsGet = true)]
        //public int CurrentPage { get; set; } = 1;

        //[BindProperty(SupportsGet = true)]
        //public string SortBy { get; set; }

        public string NameSort { get; set; }
        public string RoomSort { get; set; }
        public string BirthdateSort { get; set; }
        public string IsActiveSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int Count { get; set; }

        public string PagerInfo
        {
            get
            {
                return $"Page {Students_List.PageIndex} of {TotalPages} ({this.Count} record{(this.Count > 1 ? "s" : "")})";
            }
        }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public PaginatedList<Students_List> Students_List { get; set; }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            RoomSort = sortOrder == "Room" ? "room_desc" : "Room";
            BirthdateSort = sortOrder == "Birthdate" ? "birthdate_desc" : "Birthdate";
            IsActiveSort = sortOrder == "Is_Active" ? "isActive_desc" : "Is_Active";

            IQueryable<Students_List> list = from s in _context.Students_List
                                             select s;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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
                case "Birthdate":
                    list = list.OrderBy(s => s.Birthdate);
                    break;
                case "birthdate_desc":
                    list = list.OrderByDescending(s => s.Birthdate);
                    break;
                case "Is_Active":
                    list = list.OrderBy(s => s.Is_Active);
                    break;
                case "isActive_desc":
                    list = list.OrderByDescending(s => s.Is_Active);
                    break;
                case "Name":
                default:
                    list = list.OrderBy(s => s.Student_Name);
                    break;
            }

            Students_List = await PaginatedList<Students_List>.CreateAsync(
                list.AsNoTracking(), pageIndex ?? 1, PageSize);

            this.Count = Students_List.TotalRecordsCount;
        }
    }
}
