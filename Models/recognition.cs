﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS4200Team1.Models
{
    public class recognition
    {
        [Key]
        public int recognitionID { get; set; }

        public string description { get; set; }

        public Values values { get; set; }

        public enum Values
        {
            Stewardship,
            Culture,
            DeliveryExcellance,
            Innovation,
            GreaterGood,
            Integrity,
            Balance
        }


        public Guid id { get; set; }
        public virtual Profile Profile { get; set; }





    }
}