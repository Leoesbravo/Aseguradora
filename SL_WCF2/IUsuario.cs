using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SL_WCF2
{
    [ServiceContract]
    interface IUsuario
    {
        [OperationContract]
        SL_WCF2.Result Add(ML.Usuario usuario);
        [OperationContract]
        SL_WCF2.Result Update(ML.Usuario usuario);
        [OperationContract]
        SL_WCF2.Result Delete(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF2.Result GetById(int IdUsuario);
        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF2.Result GetAll();
    }
}
