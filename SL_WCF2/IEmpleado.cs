using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SL_WCF2
{
    interface IEmpleado
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SL_WCF2.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        SL_WCF2.Result GetById(int IdEmpleado);

        [OperationContract]
        SL_WCF2.Result Add(ML.Empleado empleado);
        [OperationContract]
        SL_WCF2.Result Update(ML.Empleado empleado);
        [OperationContract]
        SL_WCF2.Result Delete(ML.Empleado empleado);
    }
}
