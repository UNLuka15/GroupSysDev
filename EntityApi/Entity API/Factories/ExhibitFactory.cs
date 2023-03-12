using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class ExhibitFactory : IModelFactory<Exhibit, ExhibitRequestModel>
    {
        public Exhibit Create(ExhibitRequestModel exhibitRequest)
        {
            var newExhibit = new Exhibit();
            var exhibitRepository = new ExhibitRepository();

            newExhibit.Name = exhibitRequest.Name;
            newExhibit.Museum = null;
            newExhibit.Description = exhibitRequest.Description;

            var museumExhibits = exhibitRepository.GetByMuseumCode(exhibitRequest.MuseumCode);

            if (museumExhibits == null || museumExhibits.Any(e => e.Reference == exhibitRequest.Reference))
                throw new Exception($"There is already an exhibit with the reference '{exhibitRequest.Reference}'.");

            newExhibit.Reference = exhibitRequest.Reference;

            var existingMuseum = new MuseumRepository().GetByCode(exhibitRequest.MuseumCode);
            if (existingMuseum == null)
                throw new Exception($"Cannot find museum with code '{exhibitRequest.MuseumCode}'.");

            newExhibit.Museum = existingMuseum;

            DateTime parsedDate;
            if (exhibitRequest.OpeningTime != null)
            {
                if (DateTime.TryParse(exhibitRequest.OpeningTime, out parsedDate))
                    newExhibit.OpeningTime = parsedDate;
                else
                    throw new Exception("OpeningTime was in the incorrect format.");
            }

            if (exhibitRequest.ClosingTime != null)
            {
                if (DateTime.TryParse(exhibitRequest.ClosingTime, out parsedDate))
                    newExhibit.ClosingTime = parsedDate;
                else
                    throw new Exception("ClosingTime was in the incorrect format.");
            }

            return newExhibit;
        }
    }
}
