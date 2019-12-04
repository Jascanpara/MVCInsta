using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Startegy
{
    public class ComprovarClass
    {
        private readonly IStrategy _strategy;
        private readonly string _palabra;

        public ComprovarClass(IStrategy strategy, string palabra)
        {
            _strategy = strategy;
            _palabra = palabra;
        }
     
        public string Comprovar()
        {
            if (_palabra != null)
            {
                return _strategy.ComprovarP(_palabra);
            }
            else
            {
                return _palabra;
            }
        }
    }
}