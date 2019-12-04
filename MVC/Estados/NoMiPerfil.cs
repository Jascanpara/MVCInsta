using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Estados
{
    public class NoMiPerfil : IEstadoPerfil
    {
        public int Atende()
        {
                return 0;
        }
    }
}