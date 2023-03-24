using EntityAPI.Models;

namespace EntityAPI.Factories
{
    public class ReportFactory : IModelFactory<Report, ReportRequestModel>
    {
        public Report Create(ReportRequestModel requestModel)
        {
            var report = new Report();

            report.Name = requestModel.Name;
            report.GeneratedDate = DateTime.Now;
            report.ByExhibit = requestModel.ByExhibit.Value;
            report.ByFeedbackType = requestModel.ByFeedbackType.Value;
            report.ByDate = requestModel.ByDate.Value;
            report.ByKeywords = requestModel.ByKeywords.Value;

            report.StartDate = DateTime.Parse(requestModel.StartDate);
            report.EndDate = DateTime.Parse(requestModel.EndDate);

            report.Keywords = requestModel.Keywords;
            report.ExhibitCodeFilters = requestModel.ExhibitCodeFilters;
            report.FeedbackTypeFilters = requestModel.FeedbackTypeFilters;

            return report;
        }
    }
}
