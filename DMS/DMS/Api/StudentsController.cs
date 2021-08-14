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
        private readonly IStudentData db;
        private readonly DMSDataContext ef;

        public StudentsController(IStudentData _db, DMSDataContext _ef)
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

        [HttpPost, Route("Action")]
        public async Task<IActionResult> Action()
        {
            List<Student> students = await ef.Student.ToListAsync();
            DateTime Jan1_2000 = new DateTime(2000, 1, 1);
            foreach (Student st in students)
            {
                //days between OADate and Julian day 1 is 2415018.5
                //days between Dec 30, 1899 and Jan 1 2000 is 36526
                //total is 2,451,544.5
                st.BornDaysAfterJan12000 = (st.Birthdate - Jan1_2000).Days;
                //var i = 1;
            }
            await ef.SaveChangesAsync();
            return Ok();
        }

        //POST: https://localhost:44334/api/Test/PostTest,
        //Body, raw: { "added": [1,2,3], "removed": [4,5,6]}
        [HttpPost]
        [Route("ChangeStudentRoomAssignments")]
        public async Task<ActionResult> ChangeStudentRoomAssignmentsAsync([FromForm] TwoStringArraysDTO dto)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok();
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


        //POST: https://localhost:44334/api/Test/PostTest,
        //Body, raw: { "added": [1,2,3], "removed": [4,5,6]}
        [HttpPost]
        [Route("AssignGuardians")]
        public async Task<ActionResult> AssignGuardiansAsync([FromForm] TwoIntArraysDTO dto)
        {
            if (dto.ArrayOne.Length != 1)
            {
                throw new ArgumentException("Student Id was not in a proper format");
            }

            if (dto.ArrayTwo.Length == 0)
            {
                throw new ArgumentException("No guardian ids provided");
            }

            try
            {
                foreach (int item in dto.ArrayTwo)
                {
                    Person_Student ps = new Person_Student { Person_Id = item, Student_Id = dto.ArrayOne[0] };
                    ef.Parent_Student.Add(ps);
                }

                await ef.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok("done");
        }

    }
}
