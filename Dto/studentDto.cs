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

        [Required]
        public string Address { get; set; }

        public DateTime DOB { get; set; }
    }
}
