using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var paises = context.PaisGetAll().ToList();
                    result.Objects = new List<object>();
                    if (paises != null)
                    {
                        foreach (var obj in paises)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = obj.IdPais;
                            pais.Nombre = obj.Nombre;
                     
                            result.Objects.Add(pais);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
