using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BLServicios
{
    [ServiceContract]
    public interface IService1
    {
        //ESTADOS
        [OperationContract]
        string getEstados(string IdE);

        [OperationContract]
        string CrearEstado(string nombre);

        [OperationContract]
        string EditarEstado(string nombre, string id);

        [OperationContract]
        string EliminarEstado(string id);

        //REGISTROS
        [OperationContract]
        string getRegistros(string idL);

        //SISTEMAS
        [OperationContract]
        string getSistemas(string idS);

        //ACCIONES
        [OperationContract]
        string getAcciones(string idA);

        //UNIDADES
        [OperationContract]
        string getUnidades(string idU);
    }


    
}
