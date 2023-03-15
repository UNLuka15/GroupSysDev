using EntityAPI.Models;
using EntityAPI.Repositories;

namespace EntityAPI.Factories
{
    public class MuseumFactory : IModelFactory<Museum, MuseumRequestModel>
    {
        public Museum Create(MuseumRequestModel museumRequest)
        {
            var newMuseum = new Museum();
            var museumRepository = new MuseumRepository();

            newMuseum.Name = museumRequest.Name;
            newMuseum.Description = museumRequest.Description;

            var existingMuseums = museumRepository.GetAll();

            if (existingMuseums == null || existingMuseums.Any(m => m.Code == museumRequest.Code))
                throw new Exception($"There is already a museum with the code '{museumRequest.Code}'.");

            newMuseum.Code = museumRequest.Code;

            return newMuseum;
        }
    }
}
