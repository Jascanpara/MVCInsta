using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Usuario
    {
        public int Publicaciones;
        public int Seguidores;
        public int Seguidos;

        public Usuario(int publicaciones, int seguidores, int seguidos)
        {
            this.Publicaciones = publicaciones;
            this.Seguidores = seguidores;
            this.Seguidos = seguidos;
        }
    }
}