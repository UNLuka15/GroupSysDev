using EntityAPI.Factories;
using EntityAPI.Models;
using EntityAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EntityAPI.Controllers
{
    [Route("[controller]")]
    public class EmailReportController : WriteBaseController<EmailReport, EmailReportRequestModel>
    {
        public EmailReportController(IModelFactory<EmailReport, EmailReportRequestModel> factory, IRepository<EmailReport> repository) : base(factory, repository)
        {
        }
    }
}
