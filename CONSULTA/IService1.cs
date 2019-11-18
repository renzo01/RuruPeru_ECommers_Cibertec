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
    public interface Consulta
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
        List<Categoria> ListaCategoriaProd();
        [OperationContract]
        List<EstadoUsuario> ListarEstadoUsuario();
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string idUsuario { get; set; }
        [DataMember]
        public string nomUsuario { get; set; }
        [DataMember]
        public string nomDistrito { get; set; }
        [DataMember]
        public string fotoUsuario { get; set; }
        [DataMember]
        public string descripcionEstado { get; set; }
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
        public string descripcionEstado { get; set; }
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
        [DataMember] public string descripcionCategoria { get; set; }
        [DataMember] public string idProveedor { get; set; }

    }
    public class Categoria{
        [DataMember] public Int16 idCategoria { get; set; }
        [DataMember] public string descripcionCategoria { get; set; }
    }
    public class EstadoUsuario { 
        [DataMember] public Int16 idEstadoUsuario { get; set; }
        [DataMember] public string descripcionEstado { get; set; }
    }
}
