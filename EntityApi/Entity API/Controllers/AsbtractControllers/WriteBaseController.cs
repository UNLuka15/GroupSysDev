using EntityAPI.Factories;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    public abstract class WriteBaseController<T, K> : ControllerBase
    {
        protected readonly IModelFactory<T, K> _factory;
        protected readonly IRepository<T> _repository;

        public WriteBaseController(IModelFactory<T, K> factory, IRepository<T> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        [HttpPost("Add")]
        public IActionResult AddItem([FromBody] K requestModel)
        {
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

        [HttpGet("All")]
        public IActionResult GetList()
        {
            var objectList = _repository.GetAll();
            return objectList != null ? Ok(objectList) : NoContent();
        }

        [HttpGet("Single")]
        public IActionResult GetSingle(string id)
        {
            int intId;

            if (Int32.TryParse(id, out intId))
            {
                var obj = _repository.GetById(intId);
                return obj != null ? Ok(obj) : NotFound();
            }

            return BadRequest();
        }
    }
}
