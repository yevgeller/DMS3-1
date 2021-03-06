using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Data;
using DMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DMS.Pages.Student_Room
{
    public class AssignModel : PageModel
    {
        private readonly DMSDataContext db;
        public AssignModel(DMSDataContext _db)
        {
            this.db = _db;
        }

        //public IList<Models.Student> Students { get; set; }
        public IList<Models.Room> Rooms { get; set; }
        public IList<Models.Student_Room> Student_Rooms {get;set;}
        public IList<Students_List> Students_List { get; set; }
        public bool IsInRoom(int studentId, int roomId)
        {
            return Student_Rooms.Where(x => x.Student_Id == studentId && x.Room_Id == roomId).Any();
        }

        public async Task OnGet()
        {
            //Students = await db.Student.ToListAsync();
            Rooms = await db.Room.Include(x=>x.Age_Bracket).ToListAsync();
            Student_Rooms = await db.Student_Rooms.ToListAsync();
            Students_List = await db.Students_List.ToListAsync();
        }
    }
}
