using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;

namespace DMS.Pages.Room
{
    public class IndexModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public IndexModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }

        public IList<Models.Room> Rooms { get;set; }
        public IList<Models.RoomGeneralInfo_List> RoomGeneralInfo_List { get; set; }

        public async Task OnGetAsync()
        {
            Rooms = await _context.Room.Include(r => r.Age_Bracket).ToListAsync();
            RoomGeneralInfo_List = await _context.RoomGeneralInfo_List.ToListAsync();
            var i = 1;
        }
    }
}
