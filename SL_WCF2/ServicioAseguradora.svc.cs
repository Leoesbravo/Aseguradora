using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioAseguradora" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioAseguradora.svc or ServicioAseguradora.svc.cs at the Solution Explorer and start debugging.
    public class ServicioAseguradora : IServicioAseguradora
    {
        public SL_WCF2.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.AddEF(aseguradora);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.DeleteEF(aseguradora.IdAseguradora);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }

        public SL_WCF2.Result GetById(int IdAseguradora)
        {
            ML.Result result = BL.Aseguradora.GetByIdEF(IdAseguradora);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
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
