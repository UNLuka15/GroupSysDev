using EntityAPI.Models;
using EntityAPI.Repositories;

// TODO: Insert Data  DONE
//       Read Data    DONE
//       Delete Data  DONE
//       Create API
//       Tests

Console.WriteLine("Loading Context...");
var exhibitRepository = new ExhibitRepository();


// Adding 
var newExhibit = new Exhibit()
{
    Id = 1,
    Name = "Healthcare",
    Description = "An exhibit showing our recent medical advances.",
    Museum = new Museum(),
    OpeningTime = new TimeOnly(9, 0, 0),
    ClosingTime = new TimeOnly(17, 0, 0),
};

exhibitRepository.AddNew(newExhibit);
// 

// Removing
var idToRemove = 1;
exhibitRepository.RemoveById(idToRemove);
// 

// Reading
var exhibits = exhibitRepository.GetAll();

foreach (var exhibit in exhibits)
    exhibit.LogProperties();
// 
Console.WriteLine("Program complete.");
