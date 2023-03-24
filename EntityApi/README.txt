WHAT IS THIS?

This is a solution which will generate and utilise a database that will contain information used by the platform. In practice, it will running on the same server as the platform, which will be making HTTP requests to it in order to interact with the database.

It's useful to have this as a separate solution to the platform since it will make it easier to debug issues with specific models or data. 

GENERATING THE DATABASE

This solution uses code-first Entity Framework Core, so it can generate the database that it uses. If you haven't generated it yet (or want to regenrate it), please read the following. If you have, continue to RUNNING THE SOLUTION:
- Open EntityAPI.sln in Visual Studio (Tested on version 2022)
- Go to the package manager window (View > Other Windows > Package Manager Console)
- type "update-database -Verbose".
- You will now be able to find the MuseumDev database in (localdb)\mssqllocaldb, which can be accessed using SQL Server Management Studio.

! Data added by the API will appear in the MuseumDev database on the .\SQLEXPRESS server instead. 

RUNNING THE SOLUTION

Once the database is created, you'll need to run the solution in order to communicate with the API:

- Run the solution by pressing F5 or pressing the EntityAPI run button along the top bar.

COMMUNICATING WITH THE API

Once the solution is running, it will open a window to some swagger documentation on localhost in a browser. This documentation will show you each endpoint along with example requests.

You can communicate with the API through here or Insomnia/Postman while it's running. You'll also be able to send requests through code when testing.

Send the request using Basic Authentication: 
- Username: MuseumDev
- Password: GenericOrangeOpener6!

