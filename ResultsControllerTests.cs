using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Controllers;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDayAPI.Tests
{
    // Group tests for the Results controller.
    public class ResultsControllerTests
    {
        // Create a separate in-memory database for each test.
        private RaceDayDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new RaceDayDbContext(options);
        }

        // Test 1: Check that all results can be retrieved.
        [Fact]
        public async Task GetResultsReturnsAllResults()
        {
            using var context = CreateContext();

            context.Results.Add(new RaceResult
            {
                ResultId = 1,
                EnrolmentId = 10,
                ResultStatus = "Finished"
            });

            context.Results.Add(new RaceResult
            {
                ResultId = 2,
                EnrolmentId = 11,
                ResultStatus = "DNF"
            });

            await context.SaveChangesAsync();

            var controller = new ResultsController(context);

            var actionResult = await controller.GetResults();

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var results = Assert.IsType<List<RaceResult>>(okResult.Value);

            Assert.Equal(2, results.Count);
        }

        // Test 2: Check that an empty results list is returned.
        [Fact]
        public async Task GetResultsReturnsEmptyListWhenNoResultsExist()
        {
            using var context = CreateContext();

            var controller = new ResultsController(context);

            var actionResult = await controller.GetResults();

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var results = Assert.IsType<List<RaceResult>>(okResult.Value);

            Assert.Empty(results);
        }

        // Test 3: Check that an existing result can be retrieved.
        [Fact]
        public async Task GetResultReturnsResultWhenItExists()
        {
            using var context = CreateContext();

            context.Results.Add(new RaceResult
            {
                ResultId = 1,
                EnrolmentId = 10,
                ResultStatus = "Finished",
                Position = 1
            });

            await context.SaveChangesAsync();

            var controller = new ResultsController(context);

            var actionResult = await controller.GetResult(1);

            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var result = Assert.IsType<RaceResult>(okResult.Value);

            Assert.Equal(1, result.ResultId);
            Assert.Equal(1, result.Position);
        }

        // Test 4: Check that a missing result returns Not Found.
        [Fact]
        public async Task GetResultReturnsNotFoundWhenResultDoesNotExist()
        {
            using var context = CreateContext();

            var controller = new ResultsController(context);

            var actionResult = await controller.GetResult(999);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        // Test 5: Check that an existing result can be deleted.
        [Fact]
        public async Task DeleteResultRemovesExistingResult()
        {
            using var context = CreateContext();

            context.Results.Add(new RaceResult
            {
                ResultId = 1,
                EnrolmentId = 10,
                ResultStatus = "Finished"
            });

            await context.SaveChangesAsync();

            var controller = new ResultsController(context);

            var actionResult = await controller.DeleteResult(1);

            Assert.IsType<NoContentResult>(actionResult);
            Assert.Null(await context.Results.FindAsync(1));
        }

        // Test 6: Check that deleting a missing result returns Not Found.
        [Fact]
        public async Task DeleteResultReturnsNotFoundWhenResultDoesNotExist()
        {
            using var context = CreateContext();

            var controller = new ResultsController(context);

            var actionResult = await controller.DeleteResult(999);

            Assert.IsType<NotFoundResult>(actionResult);
        }
    }
}