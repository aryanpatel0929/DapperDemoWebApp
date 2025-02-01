using System.ComponentModel.DataAnnotations;

namespace DapperDemo.Data.Models
{
    public class PersonModel
    {
        [Required]
        public int PersonID { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
    }
}