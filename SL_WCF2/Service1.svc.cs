using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF2
{
    
    public class Service1 : IService1
    {
        public string Saludar(string nombre)
        {
            return string.Format("Hola" + nombre);
        }

    }
}
