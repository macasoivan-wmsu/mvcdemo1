using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Areas.Security.Models
{
    public class UserViewModel
    {
       
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage =  "Min of 3 characters.")]
        [MaxLength(10, ErrorMessage = "Max of 10 characters.")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Family name")]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }
    }
}