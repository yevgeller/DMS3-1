using DMS.Data;
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
    public class ResourcesController : ControllerBase
    {
        private readonly DMSDataContext ef;

        public ResourcesController(DMSDataContext _ef)
        {
            ef = _ef;
        }

        [HttpGet, Route("GetPersonTypes")]
        public async Task<IActionResult> GetPersonTypesAsync()
        {
            var ret = await ef.Person_Type.Select(x => x.Name).ToListAsync();
            return Ok(ret);
        }
    }
}
