using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using RuruPeru_ECommers.ServiceConsulta;
using System.Net.Http;

namespace RuruPeru_ECommers.Controllers
{

    public class RuruPeruController : Controller
    {
        //Direcciones para las apis de listado
        private const string direccionListadoUsuario = "api/listadoUsuario";
        private const string direccionListadoClientes = "api/listadoClientes";
        private const string direccionListadoProductos = "api/listadoProductos";
        private const string direccionListadoEstadoUsuario = "api/listadoEstadoUsuario";
        private const string direccionListadoCategoriaProd = "api/listadoCategoriaProd";
        //Direccion de la api
        private const string urlApi = "https://localhost:44369/";
        // GET: RuruPeru
        ConsultaClient servicioConsulta = new ConsultaClient();
        //Listados para usar en los combobox
        public IEnumerable<ServiceConsulta.EstadoUsuario> listadoEstadoUsuario() {
            List<ServiceConsulta.EstadoUsuario> listadoEstadoUsuario = new List<ServiceConsulta.EstadoUsuario>();
            using (HttpClient servicio = new HttpClient()) {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoEstadoUsuario);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.EstadoUsuario>));
                    listadoTemporal.Wait();
                    listadoEstadoUsuario = (List<ServiceConsulta.EstadoUsuario>)listadoTemporal.Result;
                }
                else {
                    listadoEstadoUsuario = new List<ServiceConsulta.EstadoUsuario>();
                }
            }
                return listadoEstadoUsuario;
        }
        public IEnumerable<ServiceConsulta.Categoria> listadoCategoriaProd()
        {
            List<ServiceConsulta.Categoria> listadoCategoriaProd = new List<ServiceConsulta.Categoria>();
            using (HttpClient servicio = new HttpClient())
            {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoCategoriaProd);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Categoria>));
                    listadoTemporal.Wait();
                    listadoCategoriaProd = (List<ServiceConsulta.Categoria>)listadoTemporal.Result;
                }
                else
                {
                    listadoCategoriaProd = new List<ServiceConsulta.Categoria>();
                }
            }
            return listadoCategoriaProd;
        }
        public IEnumerable<ServiceConsulta.Producto> listadoProducto()
        {
            List<ServiceConsulta.Producto> listadoProducto = new List<ServiceConsulta.Producto>();
            using(HttpClient servicio =  new HttpClient())
            {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoProductos);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Categoria>));
                    listadoTemporal.Wait();
                    listadoProducto = (List<ServiceConsulta.Producto>)listadoTemporal.Result;
                }
                else
                {
                    listadoProducto = new List<Producto>();
                }
            }
            return listadoProducto;
        }
        public ActionResult IndexUsuario()
        {
            List<ServiceConsulta.Usuario> temp = new List<ServiceConsulta.Usuario>();
            //indica que se va a usar un servicio que obtiene los datos de otra parte
            using (HttpClient servicio = new HttpClient())
            {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoUsuario);
                tarea.Wait();
                //guardamos el resultado del listado en una variables y verificamos si tiene datos
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listado = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Usuario>));
                    listado.Wait();
                    //guardar la lista en la lista de retorno
                    temp = (List<ServiceConsulta.Usuario>)listado.Result;
                }
                else {
                    temp = new List<ServiceConsulta.Usuario>();
                }
            }
                return View(temp);
        }
        public ActionResult IndexClientes() 
        {
            List<ServiceConsulta.Cliente> listadoCliente = new List<ServiceConsulta.Cliente>();
            using (HttpClient servicio = new HttpClient()) {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoClientes);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Cliente>));
                    listadoTemporal.Wait();
                    listadoCliente = (List<ServiceConsulta.Cliente>)listadoTemporal.Result;
                }
                else {
                    listadoCliente = new List<ServiceConsulta.Cliente>();
                }
                return View(listadoCliente);
            }
        }
        public ActionResult IndexProveedor() {
            List<ServiceConsulta.Proveedor> listadoProveedor = new List<ServiceConsulta.Proveedor>();
            using (HttpClient servicio = new HttpClient())
            {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoClientes);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Proveedor>));
                    listadoTemporal.Wait();
                    listadoProveedor = (List<ServiceConsulta.Proveedor>)listadoTemporal.Result;
                }
                else
                {
                    listadoProveedor = new List<ServiceConsulta.Proveedor>();
                }
                return View(listadoProveedor);
            }
        }
        public ActionResult IndexProductos() {
            List<ServiceConsulta.Producto> listadoProducto = new List<ServiceConsulta.Producto>();
            using (HttpClient servicio = new HttpClient()) {
                servicio.BaseAddress = new Uri(urlApi);
                var tarea = servicio.GetAsync(direccionListadoProductos);
                tarea.Wait();
                var resultado = tarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var listadoTemporal = resultado.Content.ReadAsAsync(typeof(List<ServiceConsulta.Producto>));
                    listadoTemporal.Wait();
                    listadoProducto = (List<ServiceConsulta.Producto>)listadoTemporal.Result;
                }
                else {
                    listadoProducto = new List<ServiceConsulta.Producto>();
                }
                return View(listadoProducto);
            }
        }    
        public ActionResult EliminarProducto()
        {
            
            return View();
        }      
    }
}
