using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team1.Models
{
    public class recognition
    {
        [Key]
        public System.Guid recognitionId { get; set; }

        public coreValue award {get; set;}

        public enum coreValue
        {
            Excellence = 1, 
            Integrity = 2,
            Stewardship = 3,
            Innovative = 4,
            Balance = 5,
            Passion = 6,
            Culture = 7
        }


        [Display(Name = "ID of person giving recognition")]
        public Guid recognizer { get; set; }
        [Required(ErrorMessage = "ID is required")]


        [Display(Name = "ID of person receiving the recognition")]
        public Guid recognized { get; set; }
        [Required(ErrorMessage = "Date is required")]


        [Display(Name = "Date Recognized")]
        public DateTime recognitionDate { get; set; }
        //[Required(ErrorMessage = "Date is required")]

        [Display(Name = "Public Comments")]
        public string comments { get; set; }


        public ICollection <profile> profiles { get; set; }
        public int userId { get; set; }
        public virtual profile profile { get; set; }

      

        
    }
}