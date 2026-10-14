using System;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores a participant's enrolment in a race category.
    public class Enrolment
    {
        // Unique ID for the enrolment.
        [Key]
        public int EnrolmentId { get; set; }

        // ID of the participant who enrolled.
        [Required]
        public int ParticipantId { get; set; }

        // ID of the selected event.
        [Required]
        public int EventId { get; set; }

        // ID of the selected category.
        [Required]
        public int CategoryId { get; set; }

        // Date and time the participant enrolled.
        public DateTime EnrolmentDate { get; set; } = DateTime.UtcNow;

        // Current enrolment status.
        public string Status { get; set; } = "Pending";

        // Optional race bib number.
        public int? BibNumber { get; set; }
    }
}
