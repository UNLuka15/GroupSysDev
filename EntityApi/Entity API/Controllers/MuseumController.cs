using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class MuseumController : WriteBaseController<Museum, MuseumRequestModel>
    {
        public override IModelFactory<Museum, MuseumRequestModel> _factory => new MuseumFactory();

        public override IRepository<Museum> _repository => new MuseumRepository();
    }
}
