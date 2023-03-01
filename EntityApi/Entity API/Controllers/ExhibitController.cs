using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExhibitController : ControllerBase
    {
        [HttpGet("All")]
        public List<Exhibit> GetExhibitList() 
        {
            var repository = new ExhibitRepository();
            return repository.GetAll();
        }
    }
}
