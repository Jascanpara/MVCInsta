using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Person
    {
        public string username;
        public Usuario userdata;
        //Constructor Privado
        private Person() { }

        //Propiedad privada estatica
        private static Person _instance;

        //Metodo de acceso publico para obtener la instancia
        public static Person GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Person();
            }
            return _instance;
        }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.userdata = new Usuario(userdata.Publicaciones,userdata.Seguidores,userdata.Seguidos);
            clone.username = string.Copy(username);
            return clone;
        }

        public Person Clone()
        {
            return new Person { username = username, userdata = new Usuario(userdata.Publicaciones, userdata.Seguidores, userdata.Seguidos) };
        }
    }
}