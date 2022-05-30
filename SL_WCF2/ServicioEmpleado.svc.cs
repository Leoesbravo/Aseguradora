using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioEmpleado" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioEmpleado.svc or ServicioEmpleado.svc.cs at the Solution Explorer and start debugging.
    public class ServicioEmpleado : IServicioEmpleado
    {
        public SL_WCF2.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Delete(empleado);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result GetById(string NumeroEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(NumeroEmpleado);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAll(empleado);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
