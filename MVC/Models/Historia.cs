using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Historia
    {
        [Key]
        [Display(Name = "id")]
        public int id { set; get; }

        [Display(Name = "Foto")]
        public string foto { set; get; }

        [Display(Name = "Usuario")]
        public string usuario { set; get; }
    }
}