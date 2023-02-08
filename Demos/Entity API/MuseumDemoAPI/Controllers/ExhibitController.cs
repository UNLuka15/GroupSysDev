using Microsoft.AspNetCore.Mvc;
using MuseumDemoAPI.Models;

namespace MuseumDemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExhibitController : ControllerBase
    {
        [HttpGet("All")]
        public List<Exhibit> GetExhibitList()
        {
            List<Exhibit> exhibits = new List<Exhibit>();

            using (var db = new ExhibitContext())
            {
                exhibits = db.Exhibits.ToList();
            }

            return exhibits;
        }
    }
}
