using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Poliza
    {
        public static ML.Result Add(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.PolizaAdd(poliza.Nombre, poliza.SubPoliza.IdSubPoliza, poliza.NumeroPoliza, poliza.Usuario.IdUsuario, poliza.Vigencia.FechaInicio, poliza.Vigencia.FechaFin);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.PolizaDelete(poliza.IdPoliza);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar el registro";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
            //        //using (SqlCommand cmd = new SqlCommand("UsuarioEliminar", context))
            //        {
            //            cmd.Connection = context;
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            SqlParameter collection = new SqlParameter();

            //            collection = new SqlParameter("IdUsuario", SqlDbType.Int);
            //            collection.Value = usuario.IdUsuario;

            //            cmd.Parameters.Add(collection);

            //            cmd.Connection.Open();

            //            int RowsAffected = cmd.ExecuteNonQuery();


            //            if (RowsAffected > 0)
            //            {
            //                result.Correct = true;
            //                Console.WriteLine("Se ha eliminado el registro");
            //                Console.ReadKey();
            //            }
            //            else
            //            {
            //                result.Correct = false;
            //                result.ErrorMessage = "No se pudo eliminar el registro.";
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    result.Correct = false;
            //    result.ErrorMessage = ex.Message;
            //    result.Ex = ex;
            //}

            //return result;
        }
        public static ML.Result Update(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.PolizaUpdate(poliza.IdPoliza, poliza.Nombre, poliza.SubPoliza.IdSubPoliza, poliza.NumeroPoliza, poliza.Vigencia.FechaInicio,  poliza.Vigencia.FechaFin, poliza.Usuario.IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la actualización";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var polizas = context.PolizaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (polizas != null)
                    {
                        foreach (var obj in polizas)
                        {
                            ML.Poliza poliza = new ML.Poliza();
                            poliza.IdPoliza = obj.IdPoliza;
                            poliza.Nombre = obj.PolizaNombre; poliza.NumeroPoliza = obj.NumeroPoliza;
                            poliza.FechaCreacion = obj.FechaCreacionPoliza.Value.ToString("dd/MM/yyyy");
                            poliza.FechaModificacion = obj.FechaModificacionPoliza.Value.ToString();

                            poliza.SubPoliza = new ML.SubPoliza();
                            poliza.SubPoliza.IdSubPoliza = obj.IdSubPoliza;
                            poliza.SubPoliza.Nombre = obj.SubPolizaNombre;

                            poliza.Usuario = new ML.Usuario();
                            poliza.Usuario.IdUsuario = obj.IdUsuario;
                            poliza.Usuario.NombreCompleto = obj.NombreUsuario;

                            poliza.Vigencia = new ML.Vigencia();
                            //poliza.Vigencia.IdVigencia = obj.IdVigencia;
                            poliza.Vigencia.FechaInicio = obj.FechaInicio.Value.ToString("dd/MM/yyyy");
                            poliza.Vigencia.FechaFin = obj.FechaFin.Value.ToString("dd/MM/yyyy");


                            result.Objects.Add(poliza);

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
        public static ML.Result GetbyId(int IdPoliza)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var obj = context.PolizaGetByID(IdPoliza).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Poliza poliza = new ML.Poliza();
                        poliza.IdPoliza = obj.IdPoliza;
                        poliza.Nombre = obj.PolizaNombre;
                        poliza.FechaCreacion = obj.FechaCreacionPoliza.Value.ToString("dd/MM/yyyy");
                        poliza.FechaModificacion = obj.FechaModificacionPoliza.Value.ToString();

                        poliza.SubPoliza = new ML.SubPoliza();
                        poliza.SubPoliza.IdSubPoliza = obj.IdSubPoliza;
                        poliza.NumeroPoliza = obj.NumeroPoliza;

                        poliza.Usuario = new ML.Usuario();
                        poliza.Usuario.IdUsuario = obj.IdUsuario;
                        poliza.Usuario.NombreCompleto = obj.NombreUsuario;

                        poliza.Vigencia = new ML.Vigencia();
                        poliza.Vigencia.FechaInicio = obj.FechaInicio.Value.ToString("dd/MM/yyyy");
                        poliza.Vigencia.FechaFin = obj.FechaFin.Value.ToString("dd/MM/yyyy");

                        result.Object = poliza;
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
