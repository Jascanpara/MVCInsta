using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Path
    {
        string path="";
        public Path(string _path)
        {
            path = _path;
        }

        public string ObtenerSaldo()
        {
            return path;
        }
    }
}