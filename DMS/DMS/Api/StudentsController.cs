using DMS.Data;
using DMS.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public StudentsController(IDMSData _db)
        {
            this.db = _db;
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
        public ActionResult PostTest([FromForm]TwoStringArraysDTO dto)
        {
            try
            {
                db.AssignStudentToRoom(2, 2);
                //do something with db
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            var i = dto;

            return Ok(dto);
        }


    }
}
