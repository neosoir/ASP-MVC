using System.ComponentModel.DataAnnotations;

namespace ASP.app.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string? FirstName { get; set; }

        [Display(Name = "A. Materno")]
        public string? MiddleName { get; set; }

        [Required]
        [Display(Name = "A. Paterno")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public string? Age { get; set; }

        [Required]
        [Display(Name = "Vacuna")]
        public string? Vaccine { get; set; }
    }
}
