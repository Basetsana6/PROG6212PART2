using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores a category or distance option for a race event.
    public class Category
    {
        // Unique ID for the category.
        [Key]
        public int CategoryId { get; set; }

        // ID of the event this category belongs to.
        [Required]
        public int EventId { get; set; }

        // Name of the category.
        [Required]
        public string Name { get; set; } = string.Empty;

        // Distance of the category in kilometres.
        [Range(0.01, double.MaxValue)]
        public double DistanceKm { get; set; }

        // Maximum number of participants allowed.
        [Range(1, int.MaxValue)]
        public int MaxParticipants { get; set; }

        // Entry fee for the category.
        [Range(0, double.MaxValue)]
        public decimal EntryFee { get; set; }

        // Minimum permitted participant age.
        public int MinAge { get; set; }

        // Maximum permitted participant age.
        public int MaxAge { get; set; }
    }
}
