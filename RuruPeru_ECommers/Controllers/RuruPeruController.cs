using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using RuruPeru_ECommers.ServiceReference1;

namespace RuruPeru_ECommers.Controllers
{

    public class RuruPeruController : Controller
    {

        Service1Client service = new Service1Client();


        // GET: RuruPeru
        public ActionResult Index()
        {

            string idcli = "CLI00001";

            List<ItemProducto> items = new List<ItemProducto>();

            items.Add(new ItemProducto() {
                idProducto = "PRO00002",
                precioProducto = 22.00m,
                cantidadProducto = 3
            });

            items.Add(new ItemProducto()
            {
                idProducto = "PRO00004",
                precioProducto = 42.00m,
                cantidadProducto = 5
            });

            System.Diagnostics.Debug.WriteLine(service.RealizarVenta(idcli, items.ToArray()));

            return View(service.ListarProductos());
        }

        public ActionResult Stock(string id)
        {

            ViewBag.mensaje = "";

            if(id == null)
            {
                return RedirectToAction("Index");
            }

            Producto item = service.ListarProductos().Where(x => x.idProducto == id).FirstOrDefault();

            ItemProducto reg = new ItemProducto() {
                idProducto = item.idProducto,
                precioProducto = item.precioProducto
            };


            return View(reg);
        }

        [HttpPost]
        public ActionResult Stock(ItemProducto reg)
        {

            ViewBag.mensaje = service.ActualizarStock(reg);

            return View(reg);
        }

    }
}