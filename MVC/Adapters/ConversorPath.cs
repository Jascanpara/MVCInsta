using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
using MVC.Adapters;

namespace MVC.Adapters
{
    public class ConversorPath : IConversor
    {
       string paths="";

        public ConversorPath(string foto)
        {
            paths = foto;
        }

        public string path(string foto)
        {
            string[] spearator = { "C:\\fakepath\\" };

            // using the method 
            String[] strlist = foto.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                foto = s;
            }
            return foto;
        }
    }
}