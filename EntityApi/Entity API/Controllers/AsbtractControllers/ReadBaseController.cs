﻿using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    public abstract class ReadBaseController<T> : ControllerBase
    {
        public abstract IRepository<T> _repository { get; }

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
