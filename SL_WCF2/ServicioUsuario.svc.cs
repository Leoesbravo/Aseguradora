using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioUsuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioUsuario.svc or ServicioUsuario.svc.cs at the Solution Explorer and start debugging.
    public class ServicioUsuario : IUsuario
    {
        public SL_WCF2.Result Add(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.AddEF(usuario);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result Update(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.UpdateEF(usuario);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(usuario);
            return new SL_WCF2.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SL_WCF2.Result GetById(int IdUsuario)
        {
            ML.Result result = BL.Usuario.GetbyIdEF(IdUsuario);
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
            ML.Result result = BL.Usuario.GetAllEF();
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
