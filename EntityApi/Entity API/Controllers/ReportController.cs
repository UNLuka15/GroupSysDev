using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ReportController : WriteBaseController<Report, ReportRequestModel>
    {
        public ReportController(IModelFactory<Report, ReportRequestModel> factory, IRepository<Report> repository) : base(factory, repository)
        {
        }
    }
}
