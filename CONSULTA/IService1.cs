using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CONSULTA
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.

    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Cliente> ListarClientes();

        [OperationContract]
        List<Proveedor> ListarProveedor();
        [OperationContract]
        List<Producto> ListarProductos();
        [OperationContract]
        string ActualizarStock(ItemProducto reg);
        [OperationContract]
        string RealizarVenta(string idCliente, List<ItemProducto> items);
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Cliente
    {

        [DataMember]
        public string idCliente { get; set; }
        [DataMember]
        public string apeCliente { get; set; }
        [DataMember]
        public string fechaNacCliente { get; set; }
        [DataMember]
        public string idUsuario { get; set; }

    }
    [DataContract]
    public class Proveedor
    {
        [DataMember] public string idProv { get; set; }
        [DataMember] public string nomProv { get; set; }
    }
    [DataContract]
    public class Producto
    {

        [DataMember] public string idProducto { get; set; }
        [DataMember] public string tituloProducto { get; set; }
        [DataMember] public string descripcionProducto { get; set; }
        [DataMember] public decimal precioProducto { get; set; }
        [DataMember] public int stockProducto { get; set; }
        [DataMember] public string imgProducto { get; set; }
        [DataMember] public int idCategoria { get; set; }
        [DataMember] public string idProveedor { get; set; }
    }
    [DataContract]
    public class ItemProducto
    {
        [DataMember] public string idProducto { get; set; }
        [DataMember] public int cantidadProducto { get; set; }
        [DataMember] public decimal precioProducto { get; set; }
        [DataMember]
        public decimal monto
        {
            get
            {
                return precioProducto * cantidadProducto;
            }
            set
            {

            }
        }
    }
    [DataContract]
    public class Factura
    {
        [DataMember] public string idFactura { get; set; }
        [DataMember] public decimal montoTotal { get; set; }
        [DataMember] public string fechaFactura { get; set; }
        [DataMember] public int idEstadoFactura { get; set; }
        [DataMember] public string idCliente { get; set; }

    }
    [DataContract]
    public class DetalleFactura
    {
        [DataMember] public int numDetalleFac { get; set; }
        [DataMember] public string idProducto { get; set; }
        [DataMember] public int cantidadProducto { get; set; }

    }


}
