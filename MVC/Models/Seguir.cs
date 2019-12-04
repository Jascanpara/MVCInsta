using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Seguir
    {
        [Key]
        [Display(Name = "id")]
        public int id { set; get; }

        [Display(Name = "seguidor")]
        public string seguidor { set; get; }

        [Display(Name = "seguido")]
        public string seguido { set; get; }
    }
}