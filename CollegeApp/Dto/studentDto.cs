using CollegeApp.Validators;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Dto
{
    public class studentDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Student Name is required")]
        [StringLength(30)]
        public string StudentName { get; set; }

        [EmailAddress(ErrorMessage = "Email is required")]
        public string Email { get; set; }

       // [Range(10,20)]
      //  public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        // public string Password { get; set; }

        // [Compare(nameof(Password))]
        // public string ConfirmPassword { get; set; }
        [DateCheck]
        public DateTime AdmissionDate { get; set; }
    }
}
