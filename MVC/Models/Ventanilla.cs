using MVC.Estados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Ventanilla
    {
        private IEstadoPerfil estado;

        public Ventanilla()
        {
            estado = new MiPerfil();
        }

        public int noMiPerfil()
        {
            estado = new NoMiPerfil();
            return estado.Atende();
        }

        public int miPerfil()
        {
            estado = new MiPerfil();
            return estado.Atende();
        }
    }
}