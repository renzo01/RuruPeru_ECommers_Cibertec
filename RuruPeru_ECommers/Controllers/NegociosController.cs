using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RuruPeru_ECommers.ServiceReference1;

namespace RuruPeru_ECommers.Controllers
{
    public class NegociosController : Controller
    {
        ConsultaClient servicioConsulta = new ConsultaClient();
        // GET: Negocios
        public ActionResult Index()
        {
            return View(servicioConsulta.ListarClientes());
        }
        public ActionResult IndexProducto()
        {
            return View(servicioConsulta.ListarProductos());
        }
    }
}