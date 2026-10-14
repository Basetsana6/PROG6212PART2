using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Models;
using System.Collections.Generic;

namespace RaceDayAPI.Data
{
    // This class connects the API to its database tables.
    public class RaceDayDbContext : DbContext
    {
        // This constructor passes database settings to Entity Framework.
        public RaceDayDbContext(DbContextOptions<RaceDayDbContext> options)
            : base(options)
        {
        }

        // This represents the users table.
        public DbSet<User> Users { get; set; }

        // This represents the events table.
        public DbSet<RaceEvent> Events { get; set; }

        // This represents the categories table.
        public DbSet<Category> Categories { get; set; }

        // This represents the enrolments table.
        public DbSet<Enrolment> Enrolments { get; set; }

        // This represents the results table.
        public DbSet<RaceResult> Results { get; set; }

        // This represents the event routes table.
        public DbSet<EventRoute> EventRoutes { get; set; }

        // This represents the weather snapshots table.
        public DbSet<WeatherSnapshot> WeatherSnapshots { get; set; }
    }
}

