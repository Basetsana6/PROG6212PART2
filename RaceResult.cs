using System;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores the result recorded for a race enrolment.
    public class RaceResult
    {
        // Unique ID for the result.
        [Key]
        public int ResultId { get; set; }

        // Enrolment associated with this result.
        [Required]
        public int EnrolmentId { get; set; }

        // Finishing time, if the participant finished.
        public TimeSpan? FinishTime { get; set; }

        // Finishing position, if available.
        public int? Position { get; set; }

        // Result status: Finished, DNF, DNS or DSQ.
        [Required]
        public string ResultStatus { get; set; } = "Finished";

        // Date and time the result was recorded.
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
}
