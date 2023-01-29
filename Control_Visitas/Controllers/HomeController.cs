using Control_de_Visitas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Control_Visitas.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //https://localhost:44307/

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44307/api/Usuarios");

            List<Usuario> lista_usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);


            return View(lista_usuarios);
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
    }
}