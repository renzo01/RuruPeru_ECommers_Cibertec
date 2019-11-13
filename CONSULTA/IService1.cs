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
    }
    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Cliente
    {
       
        [DataMember]
        public string idCli { get; set; }
        [DataMember]
        public string nomCli { get; set; }
        
    }
    public class Proveedor { 
        [DataMember] public string idProv { get; set; }
        [DataMember] public string nomProv { get; set; }
    }
    public class Producto { 
        [DataMember] public string idProd { get; set; }
        [DataMember] public string titulo { get; set; }
    }

}
