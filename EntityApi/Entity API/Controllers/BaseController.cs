using EntityAPI.Factories;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    public abstract class BaseController<T, K> : ControllerBase
    {
        public abstract IRepository<T> _repository { get; }
        public abstract IModelFactory<T, K> _factory { get; }

        [HttpGet("All")]
        public IActionResult GetExhibitList()
        {
            var objectList = _repository.GetAll();
            return objectList != null ? Ok(objectList) : NoContent();
        }

        //[HttpGet("ByMuseum")]
        //public IActionResult GetExhibitByMuseumList(string museumCode)
        //{
        //    var exhibitList = new ExhibitRepository().GetByMuseumCode(museumCode);
        //    return exhibitList != null ? Ok(exhibitList) : NoContent();
        //}

        [HttpGet("Single")]
        public IActionResult GetExhibit(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var obj = _repository.GetById(intId);
                return obj != null ? Ok(obj) : NotFound();
            }

            return BadRequest();
        }

        [HttpPost("Add")]
        public IActionResult AddExhibit([FromBody] K requestModel)
        {
            // Split up the translation into multiple smaller methods.
            try
            {
                var newObject = _factory.Create(requestModel);
                _repository.AddNew(newObject);

                return Ok($"'New object created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveExhibit(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var success = _repository.RemoveById(intId);

                return success ? Ok($"Object with id '{intId}' successfully removed.")
                               : NotFound($"Object with id '{intId} not found.'");
            }

            return BadRequest();
        }
    }
}
