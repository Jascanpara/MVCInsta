using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Estados
{
    public class MiPerfil : IEstadoPerfil
    {
        public int Atende()
        {
            return 1;
        }
    }
}