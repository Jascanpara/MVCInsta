using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Publicaciones
    {

        [Key]
        [Display(Name = "id")]
        public int id { set; get; }

        [Display(Name = "Descripcion")]
        public string descripcion { set; get; }

        [Display(Name = "Likes")]
        public string likes { set; get; }

        [Display(Name = "Idusuario")]
        public string idusuario { set; get; }

        [Display(Name = "Foto")]
        public string foto { set; get; }

    }
}