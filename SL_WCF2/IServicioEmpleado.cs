using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioEmpleado" in both code and config file together.
    [ServiceContract]
    public interface IServicioEmpleado
    {
        [OperationContract]
        SL_WCF2.Result Add(ML.Empleado empleado);
        [OperationContract]
        SL_WCF2.Result Update(ML.Empleado empleado);
        [OperationContract]
        SL_WCF2.Result Delete(ML.Empleado empleado);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF2.Result GetById(string NumeroEmpleado);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF2.Result GetAll(ML.Empleado empleado);
    }
}
