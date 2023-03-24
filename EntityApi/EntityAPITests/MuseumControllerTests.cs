using EntityAPI.Controllers;
using EntityAPI.Factories;
using EntityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EntityAPITests
{
    [TestClass]
    public class MuseumControllerTests
    {
        public MuseumController GetController() => new MuseumController(new MuseumFactory(), new MockMuseumRepository());

        [TestMethod]
        public void GetAllMuseums()
        {
            var controller = GetController();
            var expectedMuseums = new MockMuseumRepository().GetAll();
            
            var actualMuseums = controller.GetList() as ObjectResult;
            var result = actualMuseums.Value as List<Museum>;
            
            Assert.AreEqual(expectedMuseums, result);
        }

        [TestMethod]
        public void GetCorrectMuseum()
        {
            var controller = GetController();
            var expectedMuseum = new MockMuseumRepository().GetById(2);

            var actualMuseum = controller.GetSingle("2") as ObjectResult;
            var result = actualMuseum.Value as Museum;

            Assert.AreEqual(expectedMuseum, result);
        }

        [TestMethod]
        public void DeleteCorrectMuseum()
        {
            var controller = GetController();
            var museumToRemove = 2;

            var removedMuseumResult = controller.RemoveItem(museumToRemove.ToString()) as ObjectResult;

            var remainingMuseums = new MockMuseumRepository().GetAll();

            Assert.IsTrue(!remainingMuseums.Any(m => m.Id == museumToRemove));
        }

        [TestMethod]
        public void SuccessfullyCreateMuseum() 
        {
            var controller = GetController();

            MuseumRequestModel requestModel = new MuseumRequestModel()
            {
                Code = "MU01",
                Name = "Test Museum",
                Description = "A museum built specifically for testing."
            };

            var addedMuseumResult = controller.AddItem(requestModel) as ObjectResult;
            var result = addedMuseumResult.Value.ToString();

            var regex = new Regex("([0-9]{1,})");
            var matchResult = regex.Match(result).ToString();

            var remainingMuseums = new MockMuseumRepository().GetAll();

            Assert.IsTrue(remainingMuseums.Any(m => m.Id == Int32.Parse(matchResult)));
        }
    }
}