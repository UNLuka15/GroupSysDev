using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class EmailReportFactory : IModelFactory<EmailReport, EmailReportRequestModel>
    {
        public EmailReport Create(EmailReportRequestModel requestModel)
        {
            var emailReport = new EmailReport();
            
            // TODO: Add Safe Parsing.
            emailReport.Report = new ReportRepository().GetById(Int32.Parse(requestModel.ReportId));
            emailReport.EmailFrequency = DateTime.Parse(requestModel.EmailFrequency);
            emailReport.LastSent = DateTime.Parse(requestModel.LastSent);
            emailReport.NextDue = DateTime.Parse(requestModel.NextDue);

            return emailReport;
        }
    }
}
