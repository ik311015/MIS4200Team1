using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team1.Models
{
    public class profile
    {
        [Key]
        public System.Guid userId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "Enter your business unit")]
        [StringLength(20)]
        public string businessUnit { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "Hire Date required")]
        public System.DateTime HireDate { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter your title")]
        [StringLength(20)]
        public string title { get; set; }


    }
}