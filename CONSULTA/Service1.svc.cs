using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Configuration;

using System.Data;
using System.Data.SqlClient;

namespace CONSULTA
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString);

        public string ActualizarStock(ItemProducto reg)
        {

            string mensaje = "";

            if(reg == null)
            {
                return mensaje = "El producto que se quiere actualizar se encuenta vacio";
            }

            if(reg.cantidadProducto < 1)
            {
                return mensaje = "El producto pedido no tiene una cantidad valida -> [cantidad < 1] ";
            }

            // 20 > 20

            if(reg.cantidadProducto > 
                ListarProductos().Where(x => x.idProducto == reg.idProducto).FirstOrDefault().stockProducto)
            {
                return mensaje = "La cantidad solicitada por el cliente supera el stock actual del producto";
            }

            try
            {

                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "update tb_Producto set stockProducto = stockProducto - @stock where idProducto = @idprod;", cn);

                cmd.Parameters.AddWithValue("@stock", reg.cantidadProducto);
                cmd.Parameters.AddWithValue("@idprod", reg.idProducto);

                int rs = cmd.ExecuteNonQuery();

                mensaje = "Filas afectadas(" + rs + "): El stock del producto " + reg.idProducto + " fue modificado";

            }
            catch(SqlException e)
            {
                mensaje = e.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public List<Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }

        public List<Producto> ListarProductos()
        {
            List<Producto> temporal = new List<Producto>();

            SqlCommand cmd = new SqlCommand("select * from tb_Producto", cn);

            cn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Producto reg = new Producto()
                {
                    idProducto = dr.GetString(0),
                    tituloProducto = dr.GetString(1),
                    descripcionProducto = dr.GetString(2),
                    precioProducto = dr.GetDecimal(3),
                    stockProducto = dr.GetInt32(4),
                    imgProducto = dr.GetString(5),
                    idCategoria = dr.GetInt32(6),
                    idProveedor = dr.GetString(7)
                };

                temporal.Add(reg);
            }

            dr.Close();cn.Close();

            return temporal;
        }

        public List<Proveedor> ListarProveedor()
        {
            throw new NotImplementedException();
        }

        public string RealizarVenta(string idCliente, List<ItemProducto> items)
        {

            string mensaje = "";
            string idfactura = generarIdFactura();

            int idEstadoFactura = generarIdEstadoFactura();
            

            if (items == null)
            {
                return mensaje = "La lista de Items esta vacia";
            }

            try
            {

                SqlCommand cmd = new SqlCommand(
                    "insert into tb_Factura values (@idfac,@monto,@fecha,@idEst,@idCli)", cn);

                string date = DateTime.Now.ToString("yyyy-MM-dd");

                decimal monto = items.Sum(x => x.monto);

                cmd.Parameters.AddWithValue("@idfac", idfactura);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@fecha", date);
                cmd.Parameters.AddWithValue("@idEst", idEstadoFactura);
                cmd.Parameters.AddWithValue("@idCli", idCliente);

                cn.Open();

                cmd.ExecuteNonQuery();

                foreach (var it in items)
                {

                    cmd = new SqlCommand("insert into tb_Detalle_Factura values (@idEst,@idPro,@can)", cn);

                    cmd.Parameters.AddWithValue("@idEst", idEstadoFactura);
                    cmd.Parameters.AddWithValue("@idPro", it.idProducto);
                    cmd.Parameters.AddWithValue("@can", it.cantidadProducto);

                    cmd.ExecuteNonQuery();

                }
               
                mensaje = "Pedido registrado";
            }
            catch (SqlException e)
            {
                mensaje = "No se pudo registrar el pedido : " + e.Message;
            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        //metodo del autogenerado

        string generarIdFactura()
        {
            string cod = "";
            SqlCommand cmd;
            cmd = new SqlCommand("select MAX(idFactura) from tb_Factura", cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();

            string result = cmd.ExecuteScalar().ToString();

            if(result != "")
            {
                cod = "FAC" + (Convert.ToInt32(result.Substring(3)) + 1).ToString("D5");
            }
            else
            {
                cod = "FAC00001";
            }

            cn.Close();

            return cod;

        }

        int generarIdEstadoFactura()
        {
            int cod = 0;
            SqlCommand cmd;
            cmd = new SqlCommand("select count(*) from tb_Factura", cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();

            cod = (int)cmd.ExecuteScalar();

            cod++;

            cn.Close();

            return cod;

        }

    }
}
