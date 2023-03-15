using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ExhibitController : WriteBaseController<Exhibit, ExhibitRequestModel>
    {
        public override IModelFactory<Exhibit, ExhibitRequestModel> _factory => new ExhibitFactory();

        public override IRepository<Exhibit> _repository => new ExhibitRepository();

        // TODO: Add authorisation.

        [HttpGet("ByMuseum")]
        public IActionResult GetExhibitByMuseumList(string museumCode)
        {
            var exhibitList = new ExhibitRepository().GetByMuseumCode(museumCode);
            return exhibitList != null ? Ok(exhibitList) : NoContent();
        }
    }
}
