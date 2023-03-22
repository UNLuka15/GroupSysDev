using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class MuseumController : WriteBaseController<Museum, MuseumRequestModel>
    {
        public MuseumController(IModelFactory<Museum, MuseumRequestModel> factory, IRepository<Museum> repository) : base(factory, repository)
        {
        }
    }
}
