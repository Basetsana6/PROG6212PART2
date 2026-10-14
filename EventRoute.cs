using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores route information for a race event.
    public class EventRoute
    {
        // Unique ID for the route.
        [Key]
        public int RouteId { get; set; }

        // Event associated with this route.
        [Required]
        public int EventId { get; set; }

        // Name of the route.
        [Required]
        public string RouteName { get; set; } = string.Empty;

        // Route distance in kilometres.
        [Range(0.01, double.MaxValue)]
        public double DistanceKm { get; set; }

        // Surface type, such as road, trail or mixed.
        [Required]
        public string SurfaceType { get; set; } = string.Empty;

        // Optional link to a route map.
        public string? MapUrl { get; set; }

        // Optional elevation gain in metres.
        public double? ElevationGainM { get; set; }
    }
}
