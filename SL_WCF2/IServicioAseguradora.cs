using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF2
{
    [ServiceContract]
    public interface IServicioAseguradora
    {
        [OperationContract]
        SL_WCF2.Result Add(ML.Aseguradora aseguradora);
        [OperationContract]
        SL_WCF2.Result Update(ML.Aseguradora aseguradora);
        [OperationContract]
        SL_WCF2.Result Delete(ML.Aseguradora aseguradora);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF2.Result GetById(int IdAseguradora);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Aseguradora))]
        SL_WCF2.Result GetAll();
    }
}
