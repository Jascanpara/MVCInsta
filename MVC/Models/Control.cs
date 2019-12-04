using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Control
    {
        private Ventanilla ventanilla;

        public Control()
        {
            ventanilla = new Ventanilla();
        }

        public int atende()
        {
            return ventanilla.miPerfil();
        }

        public int cerraVentanilla()
        {
            return ventanilla.noMiPerfil();
        }
        public int abriVentanilla()
        {
            return ventanilla.miPerfil();
        }
    }
}