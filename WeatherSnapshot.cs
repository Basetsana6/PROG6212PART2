using System;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // Stores a weather forecast or snapshot for an event.
    public class WeatherSnapshot
    {
        // Unique ID for the weather snapshot.
        [Key]
        public int WeatherId { get; set; }

        // Event associated with this weather information.
        [Required]
        public int EventId { get; set; }

        // Date and time the forecast applies to.
        public DateTime ForecastDate { get; set; }

        // Recorded temperature in degrees Celsius.
        public double TemperatureC { get; set; }

        // Weather condition, such as sunny or rainy.
        [Required]
        public string Condition { get; set; } = string.Empty;

        // Wind speed in kilometres per hour.
        public double WindSpeedKmh { get; set; }

        // Date and time the weather data was retrieved.
        public DateTime RetrievedAt { get; set; } = DateTime.UtcNow;
    }
}
