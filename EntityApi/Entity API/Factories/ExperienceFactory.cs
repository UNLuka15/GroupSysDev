using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class ExperienceFactory : IModelFactory<Experience, ExperienceRequestModel>
    {
        public Experience Create(ExperienceRequestModel experienceRequest)
        {
            var newExperience = new Experience();

            var exhibit = new ExhibitRepository().GetByReference(experienceRequest.ExhibitReference, experienceRequest.MuseumCode);
            
            if (exhibit == null)
                throw new Exception($"No Exhibit found with code '{experienceRequest.ExhibitReference}' for Museum with code '{experienceRequest.MuseumCode}'.");

            newExperience.Exhibit = exhibit;
            newExperience.UploadedBy = experienceRequest.UploadedBy;
            newExperience.DateEntered = DateTime.Now;
            newExperience.Feedback = MapFeedback(experienceRequest.Feedback);

            return newExperience;
        }

        protected static Feedback MapFeedback(FeedbackRequestModel requestFeedback) 
        {
            var newFeedback = new Feedback();

            if (string.IsNullOrWhiteSpace(requestFeedback.FeedbackType))
                throw new Exception("Please specify feedback type");

            newFeedback.Type = requestFeedback.FeedbackType.ToEnum<FeedbackType>();

            var requestFeedbackLines = requestFeedback.Lines;

            if (requestFeedbackLines != null)
            {
                var newFeedbackLines = requestFeedbackLines.Select(fl => new FeedbackLine()
                {
                    Field = fl.Field,
                    Value = fl.Value,
                    DataType = fl.DataType
                }).ToList();

                newFeedback.Lines = newFeedbackLines;
            }

            return newFeedback;
        }
    }
}
