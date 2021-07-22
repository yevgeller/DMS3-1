using DMS.Data;
using DMS.Models;
using DMS.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDMSData db;
        private readonly DMSDataContext ef;

        public StudentsController(IDMSData _db, DMSDataContext _ef)
        {
            this.db = _db;
            this.ef = _ef;
        }

        [HttpGet, Route("shmabadoo")]
        public IActionResult NameDontMatter(int one)
        {
            var i = one;

            return Ok(new { Test = "Shmest", Boo = "Schmoo" });
        }

        //POST: https://localhost:44334/api/Test/PostTest,
        //Body, raw: { "added": [1,2,3], "removed": [4,5,6]}
        [HttpPost]
        [Route("ChangeStudentRoomAssignments")]
        public async Task<ActionResult> PostTest([FromForm]TwoStringArraysDTO dto)
        {
            try
            {

                //db.AssignStudentToRoom(2, 2);
                //var j = ef.Student_Rooms.ToList();
                if (dto.ArrayTwo != null)
                {
                    foreach (string item in dto.ArrayTwo)
                    {
                        Student_Room sr = ConvertStringIntoStudentRoom(item);

                        List<Student_Room> remove = await ef.Student_Rooms.Where(x => x.Room_Id == sr.Room_Id && x.Student_Id == sr.Student_Id).ToListAsync();
                        foreach (Student_Room sr_rem in remove)
                        {
                            ef.Entry(sr_rem).State = EntityState.Deleted;
                        }
                    }
                }

                if (dto.ArrayOne != null)
                {
                    foreach (string item in dto.ArrayOne)
                    {
                        Student_Room sr = ConvertStringIntoStudentRoom(item);
                        ef.Student_Rooms.Add(sr);
                    }
                }
                await ef.SaveChangesAsync();
                var ii = 1;
                //do something with db
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            var i = dto;

            return Ok(dto);
        }

        private Models.Student_Room ConvertStringIntoStudentRoom(string input)
        {
            if (input == null || String.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Cannot assign student to a room, empty argument");
            
            string[] prep = input.Split('-').ToArray();
            
            if (prep.Length != 2)
                throw new ArgumentException("Cannot assign student to a room, argument " + input + " is not in proper format");

            int studentId, roomId;
            bool flag = int.TryParse(prep[0], out studentId);

            if (!flag)
                throw new ArgumentException("Cannot convert value " + prep[0] + " to a student id");

            flag = int.TryParse(prep[1], out roomId);
            if (!flag)
                throw new ArgumentException("Cannot convert value " + prep[1] + " to a room id");

            return new Models.Student_Room { Student_Id = studentId, Room_Id = roomId };
        }


    }
}
