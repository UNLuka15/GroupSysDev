using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Single")]
        public IActionResult GetExperience(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var experience = new ExperienceRepository().GetById(intId);
                return experience != null ? Ok(experience) : NotFound();
            }

            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult AddExperience([FromBody] ExperienceRequestModel experienceRequest)
        {
            try
            {
                var newExperience = ExperienceFactory.Create(experienceRequest);
                new ExperienceRepository().AddNew(newExperience);

                return Ok($"'New experience created for exhibit '{experienceRequest.ExhibitReference}'.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveExperience(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var success = new ExperienceRepository().RemoveById(intId);

                return success ? Ok($"Experience with id '{intId}' successfully removed.")
                               : NotFound($"Experience with id '{intId} not found.'");
            }

            return BadRequest();
        }
    }
}
