using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Startegy
{
    public class ComprovarNull : IStrategy
    {
        public string ComprovarP(string palabra)
        {
            return palabra;
        }
    }
}