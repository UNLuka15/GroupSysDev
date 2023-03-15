using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class EmailReportController : WriteBaseController<EmailReport, EmailReportRequestModel>
    {
        public override IModelFactory<EmailReport, EmailReportRequestModel> _factory => new EmailReportFactory();
        public override IRepository<EmailReport> _repository => new EmailReportRepository();
    }
}
