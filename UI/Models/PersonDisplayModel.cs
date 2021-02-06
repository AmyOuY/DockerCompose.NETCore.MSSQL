using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class PersonDisplayModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage ="You need to fill in a long enough First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You need to fill in a long enough Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone { get; set; }
    }
}
