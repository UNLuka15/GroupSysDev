using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceController : ControllerBase
    {
        [HttpGet("All")]
        public IActionResult GetExperienceList()
        {
            var exhibitList = new ExperienceRepository().GetAll();
            return exhibitList != null ? Ok(exhibitList) : NoContent();
        }
    }
}
