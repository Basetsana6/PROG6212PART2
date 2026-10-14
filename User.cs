using System;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    // This class stores information about each registered user.
    public class User
    {
        // The unique ID for each user.
        [Key]
        public int UserId { get; set; }

        // The user's first name.
        [Required]
        public string FirstName { get; set; } = string.Empty;

        // The user's surname.
        [Required]
        public string LastName { get; set; } = string.Empty;

        // Each user must have a unique email address.
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Store a password hash, never a plain-text password.
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // The phone number is optional.
        public string? Phone { get; set; }

        // Identifies whether the user organises or participates in events.
        [Required]
        public string Role { get; set; } = "Participant";

        // Records when the user account was created.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
