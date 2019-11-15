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
        List<Usuario> ListarUsuarios();
        [OperationContract]
        List<Cliente> ListarClientes();
        [OperationContract]
        List<Proveedor> ListarProveedor();
        [OperationContract]
        List<Producto> ListarProductos();
        [OperationContract]
<<<<<<< HEAD
        string ActualizarStock(ItemProducto reg);
        [OperationContract]
        string RealizarVenta(string idCliente, List<ItemProducto> items);
=======
        List<Categoria> ListaCategoriaProd();
>>>>>>> 4ab53acc8bc8975b5b502766fe3cfac549266053
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario
    {
        [DataMember]
<<<<<<< HEAD
        public string idCliente { get; set; }
        [DataMember]
        public string apeCliente { get; set; }
        [DataMember]
        public string fechaNacCliente { get; set; }
        [DataMember]
        public string idUsuario { get; set; }

    }
    [DataContract]
    public class Proveedor { 
        [DataMember] public string idProv { get; set; }
        [DataMember] public string nomProv { get; set; }
    }
    [DataContract]
    public class Producto {

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
        [DataMember] public decimal monto {
            get {
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

=======
        public string idUsuario { get; set; }
        [DataMember]
        public string nomUsuario { get; set; }
        [DataMember]
        public Int16 idDistrito { get; set; }
        [DataMember]
        public string fotoUsuario { get; set; }
        [DataMember]
        public Int16 idEstado { get; set; }
    }
    public class Cliente
    {

        [DataMember]
        public string idCliente { get; set; }
        [DataMember]
        public string idUsuario { get; set; }
        [DataMember]
        public string nomUsuario { get; set; }
        [DataMember]
        public string apeCliente { get; set; }
        [DataMember]
        public DateTime fechaNacCliente { get; set; }
        [DataMember]
        public Int16 idEstado { get; set; }
        [DataMember]
        public string fotoUsuario { get; set; }
    }
    public class Proveedor {
        [DataMember] public string idProveedor { get; set; }
        [DataMember] public string idUsuario { get; set; }
        [DataMember] public string descripcionProveedor { get; set; }
        [DataMember] public string rucProveedor { get; set; }
        [DataMember] public string dniProveedor { get; set; }
    }
    public class Producto {
        [DataMember] public string idProducto { get; set; }
        [DataMember] public string tituloProducto { get; set; }
        [DataMember] public string descripcionProducto { get; set; }
        [DataMember] public decimal precioProducto { get; set; }
        [DataMember] public Int32 stockProducto { get; set; }
        [DataMember] public string imgProducto { get; set; }
        [DataMember] public Int16 idCategoria { get; set; }
        [DataMember] public string idProveedor { get; set; }
>>>>>>> 4ab53acc8bc8975b5b502766fe3cfac549266053

    }
    public class Categoria{
        [DataMember] public Int16 idCategoria { get; set; }
        [DataMember] public string descripcionCategoria { get; set; }
    }
}
