using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CONSULTA
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RuruPeru_DB"].ConnectionString);
        public List<Categoria> ListaCategoriaProd()
        {
            List<Categoria> temp = new List<Categoria>();
            SqlCommand cmd = new SqlCommand("usp_listar_categoria", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Categoria reg = new Categoria
                {
                    idCategoria = dr.GetInt16(0),
                    descripcionCategoria = dr.GetString(1)
                };
            }
            dr.Close(); cn.Close();
            return temp;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> temp =  new List<Cliente>();
            SqlCommand cmd =  new SqlCommand("usp_listar_Cliente",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Cliente reg = new Cliente()
                {
                    idCliente = dr.GetString(0),
                    nomUsuario = dr.GetString(1),
                    apeCliente = dr.GetString(2),
                    fechaNacCliente = dr.GetDateTime(3),
                    descripcionEstado = dr.GetString(4),
                    idUsuario = dr.GetString(5),
                    fotoUsuario = dr.GetString(6)
                };
                temp.Add(reg);
            }
            dr.Close();cn.Close();
            return temp;
        }

        public List<EstadoUsuario> ListarEstadoUsuario()
        {
            List<EstadoUsuario> temp = new List<EstadoUsuario>();
            SqlCommand cmd = new SqlCommand("usp_listar_EstadoUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                EstadoUsuario reg = new EstadoUsuario()
                {
                    idEstadoUsuario = dr.GetInt16(0),
                    descripcionEstado = dr.GetString(1)
                };
                temp.Add(reg);
            }
            dr.Close(); cn.Close();
            return temp;
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> temp = new List<Producto>();
            SqlCommand cmd = new SqlCommand("usp_listar_Producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Producto reg = new Producto()
                {
                    idProducto = dr.GetString(0),
                    tituloProducto = dr.GetString(1),
                    descripcionProducto = dr.GetString(2),
                    precioProducto = dr.GetDecimal(3),
                    stockProducto = dr.GetInt32(4),
                    imgProducto = dr.GetString(5),
                    descripcionCategoria = dr.GetString(6),
                    idProveedor = dr.GetString(7)
                };
                dr.Close(); cn.Close();
            }
            return temp;
        }

        public List<Proveedor> ListarProveedor()
        {
            List<Proveedor> temp = new List<Proveedor>();
            SqlCommand cmd = new SqlCommand("usp_listar_Proveedor", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Proveedor reg = new Proveedor()
                {
                    idProveedor = dr.GetString(0),
                    descripcionProveedor = dr.GetString(1),
                    rucProveedor = dr.GetString(2),
                    dniProveedor = dr.GetString(3),
                    idUsuario = dr.GetString(4)
                };
                temp.Add(reg);
            }
            dr.Close(); cn.Close();
            return temp;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> temp = new List<Usuario>();
            SqlCommand cmd = new SqlCommand("usp_listar_Usuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Usuario reg = new Usuario()
                {
                    idUsuario = dr.GetString(0),
                    nomUsuario = dr.GetString(1),
                    nomDistrito = dr.GetString(2),
                    fotoUsuario = dr.GetString(3),
                    descripcionEstado = dr.GetString(4)
                };
                temp.Add(reg);
            }
            dr.Close(); cn.Close();
            return temp;
        }
    }
}
