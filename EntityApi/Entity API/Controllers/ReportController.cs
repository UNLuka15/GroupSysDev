using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class ReportController : WriteBaseController<Report, ReportRequestModel>
    {
        public override IModelFactory<Report, ReportRequestModel> _factory => new ReportFactory();

        public override IRepository<Report> _repository => new ReportRepository();
    }
}
