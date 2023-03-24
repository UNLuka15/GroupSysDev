using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ExperienceController : WriteBaseController<Experience, ExperienceRequestModel>
    {
        public ExperienceController(IModelFactory<Experience, ExperienceRequestModel> factory, IRepository<Experience> repository) : base(factory, repository)
        {
        }
    }
}
