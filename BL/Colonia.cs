using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetByIdMunicipio(int IdMunicipio)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var colonias = context.ColoniaGetById(IdMunicipio).ToList();
                    result.Objects = new List<object>();

                    if (colonias != null)
                    {
                        foreach (var obj in colonias)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = obj.IdColonia;
                            colonia.Nombre = obj.Nombre;
                            colonia.CodigoPostal = obj.CodigoPostal;
                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;


                            result.Objects.Add(colonia);
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
