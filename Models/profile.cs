using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team1.Models
{

    public class Profile
    {
        [Key]
        public Guid ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*Required")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*Required")]
        public string lastName { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "*Required")]
        public bUnit businessUnit { get; set; }

        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "*Required")]
        public string hireDate { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "*Required")]
        public title Title { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "*Required")]
        public string phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "*Required")]
        public string email { get; set; }

        public enum bUnit
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            India,
            Indianapolis,
            Louisville,
            Miami,
            Seattle,
            [Display(Name = "St. Louis")]
            StLouis,
            Tampa
        }

        public enum title
        {
            Consultant,
            [Display(Name = "Senior Consultant")]
            SeniorConsultant,
            Manager,
            Architect,
            [Display(Name = "Senior Manager")]
            SeniorManager,
            Director,
            VP
        }
        ICollection<recognition> Recognition { get; set; }

        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }

    }
}