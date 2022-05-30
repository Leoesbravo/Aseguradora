using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class Estado
    {
        public static ML.Result GetByIdPais(int IdPais)
        {
            
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var estados = context.EstadoGetById(IdPais).ToList();
                    result.Objects = new List<object>();

                    if (estados != null)
                    {
                        foreach(var objEstado in estados)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = objEstado.IdEstado;
                            estado.Nombre = objEstado.Nombre;
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = objEstado.IdPais.Value;


                            result.Objects.Add(estado); 
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
