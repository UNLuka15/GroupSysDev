using EntityAPI.Models;

Console.WriteLine("Loading Context...");

using (var context = new Context()) 
{
    var exhibits = context.Exhibits?.ToList();
    Console.WriteLine(exhibits);
}

Console.WriteLine("Program complete.");
