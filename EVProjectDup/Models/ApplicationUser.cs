using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EVProjectDup.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]

        public string CarName { get; set; }

        [Required]
        public string CarNumber { get; set;}

        [Required]

        public string Address { get; set;}

    }
}
