using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ExperienceController : WriteBaseController<Experience, ExperienceRequestModel>
    {
        public override IModelFactory<Experience, ExperienceRequestModel> _factory => new ExperienceFactory();

        public override IRepository<Experience> _repository => new ExperienceRepository();
    }
}
