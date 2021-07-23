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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DMSDataContext ef;
        public TeacherController(DMSDataContext _ef)
        {
            this.ef = _ef;
        }

        [HttpPost]
        [Route("ChangeTeacherRoomAssignments")]
        public async Task<ActionResult> ChangeTeacherRoomAssignmentsAsync([FromForm] TwoStringArraysDTO dto)
        {
            try
            {
                if (dto.ArrayTwo != null)
                {
                    foreach (string item in dto.ArrayTwo)
                    {
                        Person_Room pr = ConvertStringIntoPersonRoom(item);

                        List<Person_Room> remove = await ef.Person_Room
                            .Where(x => x.Room_Id == pr.Room_Id && x.Person_Id == pr.Person_Id)
                            .ToListAsync();
                        foreach (Person_Room pr_rem in remove)
                        {
                            ef.Entry(pr_rem).State = EntityState.Deleted;
                        }
                    }
                }

                if (dto.ArrayOne != null)
                {
                    foreach (string item in dto.ArrayOne)
                    {
                        Person_Room pr = ConvertStringIntoPersonRoom(item);
                        ef.Person_Room.Add(pr);
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


        private Models.Person_Room ConvertStringIntoPersonRoom(string input)
        {
            if (input == null || String.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Cannot assign student to a room, empty argument");

            string[] prep = input.Split('-').ToArray();

            if (prep.Length != 2)
                throw new ArgumentException("Cannot assign teacher to a room, argument " + input + " is not in proper format");

            int personId, roomId;
            bool flag = int.TryParse(prep[0], out personId);

            if (!flag)
                throw new ArgumentException("Cannot convert value " + prep[0] + " to a person id");

            flag = int.TryParse(prep[1], out roomId);
            if (!flag)
                throw new ArgumentException("Cannot convert value " + prep[1] + " to a room id");

            return new Models.Person_Room { Person_Id = personId, Room_Id = roomId };
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
