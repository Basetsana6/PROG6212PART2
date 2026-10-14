using System;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores details about a race event.
    public class RaceEvent
    {
        // Unique identifier for the event.
        [Key]
        public int EventId { get; set; }

        // ID of the user organising the event.
        [Required]
        public int OrganiserId { get; set; }

        // Name of the race event.
        [Required]
        public string Name { get; set; } = string.Empty;

        // Description of the event.
        public string Description { get; set; } = string.Empty;

        // Date and time when the event takes place.
        public DateTime EventDate { get; set; }

        // Physical location of the event.
        [Required]
        public string Location { get; set; } = string.Empty;

        // Event type, such as Running, Walking or Cycling.
        [Required]
        public string EventType { get; set; } = "Running";

        // Current status of the event.
        public string Status { get; set; } = "Upcoming";

        // Date and time when the event was created.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
