# PROG6212PART2
# RaceDayAPI

## 1. Project Overview

RaceDayAPI is a web API developed to manage information related to race events. It uses ASP.NET Core and Entity Framework Core to handle data and communicate with a database.

The API is organised into controllers, models and a database context to keep the code structured and easier to maintain.

## 2. Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL database configured for the project
* xUnit for unit testing
* Entity Framework Core InMemory provider for testing

## 3. Project Features

The project contains data models and database tables for:

* Users
* Race events
* Categories
* Enrolments
* Race results
* Event routes
* Weather snapshots

The Results controller includes functionality to retrieve all race results, retrieve a result by ID, create a result and delete a result.

When creating a result, the controller checks whether the related enrolment exists before saving the result.

## 4. Project Structure

* **Controllers:** Handle API requests and responses.
* **Models:** Define the data structures used by the application.
* **Data:** Contains the RaceDayDbContext, which connects the application to its database tables.
* **Tests:** Contains automated tests used to check controller functionality.
* **Program.cs:** Configures and starts the application.

## 5. How to Run the Project

1. Open the RaceDayAPI solution in Visual Studio.
2. Restore the NuGet packages.
3. Check that the database connection string and database configuration are correct for your environment.
4. Build the solution and resolve any errors.
5. Set RaceDayAPI as the startup project.
6. Run the application using Visual Studio.

If Swagger is configured, it can be used to view and test the available API endpoints.

## 6. Unit Testing

The project uses xUnit to run automated tests.

The ResultsControllerTests class tests the Results controller using an in-memory database. Each test creates a separate database to avoid test data affecting other tests.

The tests check that:

1. All results can be retrieved.
2. An empty list is returned when no results exist.
3. An existing result can be retrieved by ID.
4. A missing result returns Not Found.
5. An existing result can be deleted.
6. Deleting a missing result returns Not Found.

To run the tests, open **Test Explorer** in Visual Studio and select **Run All Tests**.

## 7. Purpose of the Tests

The unit tests help verify that the Results controller behaves as expected in different situations. They also help identify problems when the code is changed.

## 8. Conclusion

RaceDayAPI provides a structured way to manage race-related information. Using controllers, models, Entity Framework Core and automated unit tests helps make the application easier to understand, maintain and test.
