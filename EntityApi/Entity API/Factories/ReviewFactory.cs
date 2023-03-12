using EntityAPI.Models;

namespace EntityAPI.Factories
{
    public class ReviewFactory : IModelFactory<Review, ReviewRequestModel>
    {
        public Review Create(ReviewRequestModel requestModel)
        {
            var newReview = new Review();

            newReview.Provider = requestModel.Provider;

            DateTime parsedDate;
            if (requestModel.Date != null)
            {
                if (DateTime.TryParse(requestModel.Date, out parsedDate))
                    newReview.Date = parsedDate;
                else
                    throw new Exception("Date was in the incorrect format.");
            }

            newReview.Content = MapFeedback(requestModel.Content);

            return newReview;
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
