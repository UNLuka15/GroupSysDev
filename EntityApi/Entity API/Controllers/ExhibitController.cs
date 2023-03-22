using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ExhibitController : WriteBaseController<Exhibit, ExhibitRequestModel>
    {
        public ExhibitController(IModelFactory<Exhibit, ExhibitRequestModel> factory, IRepository<Exhibit> repository) : base(factory, repository)
        {
        }

        [HttpGet("ByMuseum")]
        public IActionResult GetExhibitByMuseumList(string museumCode)
        {
            var exhibitList = new ExhibitRepository().GetByMuseumCode(museumCode);
            return exhibitList != null ? Ok(exhibitList) : NoContent();
        }
    }
}
