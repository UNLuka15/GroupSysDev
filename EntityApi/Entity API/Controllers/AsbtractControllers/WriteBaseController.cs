using EntityAPI.Factories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    public abstract class WriteBaseController<T, K> : ReadBaseController<T>
    {
        public abstract IModelFactory<T, K> _factory { get; }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] K requestModel)
        {
            // Split up the translation into multiple smaller methods.
            try
            {
                var newObject = _factory.Create(requestModel);
                var newId = _repository.AddNew(newObject);

                return Ok($"New object created with id '{newId}'.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveItem(string id)
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
