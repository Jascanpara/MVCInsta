using MVC.Models;
using MVC.Startegy;
using MVC.Estados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using MVC.DataAccess;
using System.Data.SqlClient;
using System.Web.Security;
using MVC.Adapters;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AmigoDataService _dataService;
        Person p1 = Person.GetInstance();
        private static Path _path;
        private static ConversorPath _conversor;
        public HomeController()
        {
            var connectionString = System.Configuration.ConfigurationManager.
                ConnectionStrings["SQLConnection"].ConnectionString;
            _dataService = new AmigoDataService(connectionString);
        }

        public ActionResult Index()
        {
            var amigos = _dataService.GetAmigos();
            return View(amigos);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Publicar()
        {
            return View();
        }

        public ActionResult SubirHistoria()
        {
            return View();
        }

        public ActionResult Publicaciones()
        {
            var publi = _dataService.GetPubli();
            return View(publi);
        }
        public ActionResult Historias()
        {
            var histo = _dataService.GetHistoria();
            return View(histo);
        }
        public ActionResult AddView()
        {
            var amigo = new Amigo();
            return View(amigo);
        }

        public ActionResult Delete(int i)
        {
            var result = _dataService.DeleteSeguido(i);
            return RedirectToAction("Seguidos");
        }

        public ActionResult MisPublicaciones(string i)
        {
            var sort = new ComprovarClass(new ComprovarNull(), i);
            var result = sort.Comprovar();
            var publi = _dataService.GetPubli();
            var publis = new Publicaciones();

            foreach (var item in publi)
            {
                if (item.idusuario == result)
                {
                    publis = item;
                }
            }
            return View(publis);
        }

        public ActionResult MisHistorias(string i)
        {
            var histo = _dataService.GetHistoria();
            var histos = new Historia();

            foreach (var item in histo)
            {
                if (item.usuario == i)
                {
                    histos = item;
                }
            }
            return View(histos);
        }

        public ActionResult UpdateVeiw(string i)
        {
            var amigos = _dataService.GetAmigos();
            var amigo = new Amigo();

            foreach (var item in amigos)
            {
                if(item.usuario == i)
                {
                    amigo = item;
                }
            }
            return View(amigo);
        }

        [HttpPost]
        public ActionResult UpdateVeiw(Amigo amigo)
        {
            if (!ModelState.IsValid) return View(amigo);

            var result = _dataService.RefreshAmigo(amigo);

            if (result)
                return RedirectToAction("Index");

            return View(amigo);
        }

        [HttpPost]
        public ActionResult AddView(Amigo amigo)
        {
            if (!ModelState.IsValid) return View(amigo);

            var result = _dataService.AddAmigo(amigo);

            if (result)
                return RedirectToAction("Index");

            return View(amigo);
        }
        
       public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Seguidores()
        {
            var seguidores = _dataService.GetSeguidor();
            return View(seguidores);
        }

        public ActionResult Seguidos()
        {
            var seguidores = _dataService.GetSeguidor();
            return View(seguidores);
        }

        public ActionResult Notificaciones()
        {
            var seguidores = _dataService.GetSeguidor();
            return View(seguidores);
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult Perfil1(string i)
        {
            var amigos = _dataService.GetAmigos();
            var amigo = new Amigo();

            foreach (var item in amigos)
            {
                if (item.usuario == i)
                {
                    amigo = item;
                }
            }
            return View(amigo);
        }

        public ActionResult Registro()
        {
            ViewBag.Message = "Your register page.";

            return View();
        }

        [HttpPost]
        public JsonResult LogIn(string usuario, string password)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT usuario, contrasena FROM amigos WHERE usuario = @usuario AND contrasena = @pas ", con);
            cmd.Parameters.AddWithValue("usuario", usuario);
            cmd.Parameters.AddWithValue("pas", password);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Json(1);
            }
            else
            {
                return Json(-1);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public string ObtenerPath(string foto)
        {
            _conversor = new ConversorPath(foto);
            return _conversor.path(foto);
        }
        public void insertar(string foto, string telefono, string nombre, string usuario, string contrasena,int seguidores, int seguidos, int publicaciones, string frase)
        {
            string[] spearator = { "C:\\fakepath\\" };

            // using the method 
            String[] strlist = foto.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                foto = s;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            string query = "INSERT INTO amigos (foto,telefono,nombre,usuario,contrasena,seguidores,seguidos,publicaciones,frase) VALUES (@foto,@telefono,@nombre,@usuario,@contrasena,@seguidores,@seguidos,@publicaciones,@frase)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contrasena", contrasena);
            cmd.Parameters.AddWithValue("@seguidores", seguidores);
            cmd.Parameters.AddWithValue("@seguidos", seguidos);
            cmd.Parameters.AddWithValue("@publicaciones", publicaciones);
            cmd.Parameters.AddWithValue("@frase", frase);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [HttpPost]
        public JsonResult registrar(string foto,string telefono, string nombre, string usuario, string contrasena)
        {
            p1.username = "";
            p1.userdata = new Usuario(0, 0, 0);
            Person p2 = p1.Clone();
            p1.username = usuario;
            p1.userdata.Seguidores = 0;
            p1.userdata.Seguidos = 0;
            p1.userdata.Publicaciones = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT usuario FROM amigos WHERE usuario=@usuario", con);
            cmd.Parameters.AddWithValue("@usuario", p1.username);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count < 1)
            {
                //acá insertamos usuario y contraseña a la base de datos
                con.Close();
                insertar(foto,telefono,nombre,usuario,contrasena,p2.userdata.Seguidores,p2.userdata.Seguidos,p2.userdata.Publicaciones, "Hi I'm using instagram");
                con.Open();
                FormsAuthentication.SetAuthCookie(p1.username, false);
                return Json(1);
            }
            else
            {
                return Json(-1);
            }
        }

        public void insertarSeguidor(string seguidor, string seguido)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            string query = "INSERT INTO Seguir (seguidor,seguido) VALUES (@seguidor,@seguido)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@seguidor", seguidor);
            cmd.Parameters.AddWithValue("@seguido", seguido);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        [HttpPost]
        public JsonResult Seguir(string seguidor, string seguido)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT seguidor,seguido FROM Seguir WHERE seguidor=@seguidor AND seguido=@seguido", con);
            cmd.Parameters.AddWithValue("@seguidor", seguidor);
            cmd.Parameters.AddWithValue("@seguido", seguido);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                //acá insertamos usuario y contraseña a la base de datos
                con.Close();
                insertarSeguidor(seguidor, seguido);
                con.Open();
                return Json(1);
            }
            else
            {
                return Json(-1);
            }
        }

        public JsonResult PublicarFoto(string foto, string descripcion, string usuario)
        {
            string[] spearator = { "C:\\fakepath\\" };

            // using the method 
            String[] strlist = foto.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                foto = s;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            string query = "INSERT INTO publicaciones (foto,descripcion,likes,idusuario) VALUES (@foto,@descripcion,@likes,@idusuario)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@likes", 0);
            cmd.Parameters.AddWithValue("@idusuario", usuario);
            cmd.ExecuteNonQuery();
            con.Close();
            return Json(1);
        }

        public JsonResult SubirHistorias(string foto, string descripcion, string usuario)
        {
            string a = ObtenerPath(foto);
            string[] spearator = { "C:\\fakepath\\" };

            // using the method 
            String[] strlist = foto.Split(spearator,
           StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                foto = s;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=JSPALACIOS\SQLEXPRESS01;Initial Catalog=agenda;Integrated Security=True";
            con.Open();
            string query = "INSERT INTO historias (foto,usuario) VALUES (@foto,@usuario)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@foto", foto);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.ExecuteNonQuery();
            con.Close();
            return Json(1);
        }
    }
}