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
        public List<Models.Person> Persons;
        public List<Models.Room> Rooms;
        public AssignModel(DMSDataContext _ef)
        {
            this.ef = _ef;
        }
        public async void OnGetAsync()
        {
            Persons = await ef.Person.ToListAsync();
            Rooms = await ef.Room.ToListAsync();
        }

        public async Task<bool> IsInRoomAsync(int personId, int roomId)
        {
            return await ef.Person_Room.AnyAsync(x => x.Person_Id == personId && x.Room_Id == roomId);
        }
    }
}
