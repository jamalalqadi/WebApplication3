using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.ViewModels.Identity
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Frist Name")]
        public string FristName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public IEnumerable<string> NameRoles { get; set; }

        public List<RoleViewModel> Roles { get; set; }

    }
}