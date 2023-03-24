using EntityAPI.Controllers;
using EntityAPI.Factories;
using EntityAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}