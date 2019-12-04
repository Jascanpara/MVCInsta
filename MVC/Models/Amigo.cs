using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Amigo
    {

        [Key]
        [Display(Name = "ID")]
        public int idamigo { set; get; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre es Requerido")]
        public string nombre { set; get; }

        [Display(Name = "Telefono")]
        public string telefono { set; get; }

        [Display(Name = "Usuario")]
        public string usuario { set; get; }

        [Display(Name = "Seguidores")]
        public string seguidores { set; get; }

        [Display(Name = "Seguidos")]
        public string seguidos { set; get; }

        [Display(Name = "Contrasena")]
        public string contrasena { set; get; }

        [Display(Name = "Publicaciones")]
        public string publicaciones { set; get; }

        [Display(Name = "Frase")]
        public string frase { set; get; }

        [Display(Name = "Foto")]
        public string foto { set; get; }
    }
}