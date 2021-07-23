using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DMS.Pages.Person_Room
{
    public class AssignModel : PageModel
    {
        private readonly DMSDataContext ef;
        public List<Models.Person> Teachers;
        public List<Models.Room> Rooms;
        public List<Models.Person_Room> Teacher_Rooms;
        public AssignModel(DMSDataContext _ef)
        {
            this.ef = _ef;
        }
        public async void OnGetAsync()
        {
            List<Models.Person_Type> types = await ef.Person_Type.ToListAsync();
            List<int> teacherTypes = await ef.Person_Type
                .Where(x => x.Name.Contains("Teacher"))
                .Select(x => x.Person_Type_Id)
                .ToListAsync();
            Teachers = await ef.Person
                .Where(x=>teacherTypes.Contains(x.Person_Type_Id))
                .ToListAsync();
            List<int> teacherIds = Teachers.Select(x => x.Person_Id).ToList();
            Teacher_Rooms = await ef.Person_Room
                .Where(x => teacherIds.Contains(x.Person_Id)).ToListAsync();

            Rooms = await ef.Room.ToListAsync();
        }

        public bool IsInRoomAsync(int personId, int roomId)
        {
            return Teacher_Rooms
                .Where(x => x.Person_Id == personId && x.Room_Id == roomId)
                .Any();
        }
    }
}
