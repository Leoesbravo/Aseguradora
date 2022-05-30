using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
   public  class Aseguradora
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AseguradoraAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        {
                            cmd.Connection = context;
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure;


                            SqlParameter[] collection = new SqlParameter[2];

                            collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                            collection[0].Value = aseguradora.Nombre;

                            collection[1] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                            collection[1].Value = aseguradora.Usuario.IdUsuario;

                            cmd.Parameters.AddRange(collection);

                            cmd.Connection.Open();

                            int RowsAffected = cmd.ExecuteNonQuery();

                            cmd.Connection.Close();

                            if (RowsAffected > 0)
                            {
                                result.Correct = true;
                                Console.WriteLine("Se ha actualizado la DB");
                                Console.ReadKey();
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se ha podido dar de alta la aseguradora";
                            }
                        }
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
        public static ML.Result Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("AseguradoraDelete", context))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter collection = new SqlParameter();

                        collection = new SqlParameter("IdAseguradora", SqlDbType.Int);
                        collection.Value = aseguradora.IdAseguradora;

                        cmd.Parameters.Add(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();


                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            Console.WriteLine("Se ha eliminado el registro");
                            Console.ReadKey();
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo eliminar el registro.";
                        }
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
        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand("AseguradoraUpdate", context))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdAseguradora", SqlDbType.Int);
                        collection[0].Value = aseguradora.IdAseguradora;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = aseguradora.Nombre;

                        collection[2] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[2].Value = aseguradora.Usuario.IdUsuario;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            Console.WriteLine("Se ha actualizado la DB");
                            Console.ReadKey();
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El registro no pudo ser modificado.";
                        }
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand("AseguradoraGetAll"))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAseguradora = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAseguradora);

                        if (tableAseguradora.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAseguradora.Rows)
                            {
                                ML.Aseguradora aseguradora = new ML.Aseguradora();
                                aseguradora.Usuario = new ML.Usuario();

                                aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                                aseguradora.Nombre = row[1].ToString();
                                aseguradora.FechaCreacion = row[2].ToString();
                                aseguradora.FechaModificacion = row[3].ToString();
                                aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());

                                result.Objects.Add(aseguradora);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla";
                        }
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
        public static ML.Result GetById(int IdAseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = ("AseguradoraGetByID");

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAseguradora", SqlDbType.Int);
                        collection[0].Value = IdAseguradora;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];


                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.IdAseguradora = int.Parse(row[0].ToString());
                            aseguradora.Nombre = row[1].ToString();
                            aseguradora.FechaCreacion = row[2].ToString();
                            aseguradora.FechaModificacion = row[3].ToString();
                            aseguradora.Usuario.IdUsuario = int.Parse(row[4].ToString());

                            result.Object = aseguradora;
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No existen registros en la tabla ";
                        }
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
        public static ML.Result DeleteEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            //ML.Aseguradora aseguradora = new ML.Aseguradora();
            //aseguradora.IdAseguradora = IdAseguradora;
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.AseguradoraDelete(IdAseguradora);

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
        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el update";
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
        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

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
        public static ML.Result GetByIdEF(int IdAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var objAseguradora = context.AseguradoraGetById(IdAseguradora).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (objAseguradora != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = objAseguradora.IdAseguradora;
                        aseguradora.Nombre = objAseguradora.Nombre;
                        aseguradora.FechaCreacion = objAseguradora.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = objAseguradora.FechaModificacion.ToString();

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = objAseguradora.IdUsuario.Value;

                        result.Object = aseguradora;
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var usuarios = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>();
                    if (usuarios != null)
                    {
                        foreach (var objAseguradora in usuarios)
                        {
                                
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = objAseguradora.IdAseguradora;
                            aseguradora.Nombre = objAseguradora.AseguradoraNombre;
                            aseguradora.FechaCreacion = objAseguradora.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = objAseguradora.FechaModificacion.ToString();
                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = objAseguradora.IdUsuario;
                            aseguradora.Usuario.UserName = objAseguradora.UserName;
                            aseguradora.Usuario.Nombre = objAseguradora.UsuarioNombre;
                            aseguradora.Usuario.ApellidoPaterno = objAseguradora.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno = objAseguradora.ApellidoMaterno;

                            result.Objects.Add(aseguradora);

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
        public static ML.Result AddLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    DL_EF.Aseguradora aseguradoralinq = new DL_EF.Aseguradora();
                    aseguradoralinq.Nombre = aseguradora.Nombre;
                    aseguradoralinq.FechaCreacion = DateTime.Now;
                    aseguradoralinq.FechaModificacion = DateTime.Now;
                    aseguradoralinq.IdUsuario = aseguradora.Usuario.IdUsuario;

                    Context.Aseguradoras.Add(aseguradoralinq);
                    Context.SaveChanges();
                    result.Correct = true;
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
        public static ML.Result DeleteLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result Result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var resultQuery = (from aseguradoraItem in context.Aseguradoras
                                       where aseguradoraItem.IdAseguradora == aseguradora.IdAseguradora
                                       select aseguradoraItem).FirstOrDefault();
                    if (resultQuery != null)
                    {
                        context.Aseguradoras.Remove(resultQuery);
                        context.SaveChanges();

                        Result.Correct = true;
                    }
                    else
                    {
                        Result.Correct = false;
                        Result.ErrorMessage = "No se pudo eliminar el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }
        public static ML.Result UpdateLINQ(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var resultQuery = (from asguradoraitem in context.Aseguradoras
                                       where asguradoraitem.IdAseguradora == aseguradora.IdAseguradora
                                       select asguradoraitem).FirstOrDefault();
                    if (resultQuery != null)
                    {
                        resultQuery.Nombre = aseguradora.Nombre;
                        resultQuery.FechaModificacion = DateTime.Now;
                        resultQuery.IdUsuario = aseguradora.Usuario.IdUsuario;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
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
        public static ML.Result GetByIdLINQ(int IdAseguradora)
        {
            ML.Result Result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var ResultQuery = (from aseguradora in Context.Aseguradoras
                                       where aseguradora.IdAseguradora == IdAseguradora
                                       select new
                                       {
                                           aseguradora.IdAseguradora,
                                           aseguradora.Nombre,
                                           aseguradora.FechaCreacion,
                                           aseguradora.FechaModificacion,
                                           aseguradora.Usuario.IdUsuario,
                                       }).FirstOrDefault();

                    Result.Objects = new List<object>();

                    if (ResultQuery != null)
                    {

                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = ResultQuery.IdAseguradora;
                        aseguradora.Nombre = ResultQuery.Nombre;
                        aseguradora.FechaCreacion = ResultQuery.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = ResultQuery.FechaModificacion.ToString();
                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = ResultQuery.IdUsuario;

                        Result.Object = aseguradora;
                        Result.Correct = true;
                    }
                    else
                    {
                        Result.Correct = false;
                        Result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result Result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var ResultQuery = from aseguradora in Context.Aseguradoras
                                      select aseguradora;

                    Result.Objects = new List<object>();
                    if (ResultQuery != null)
                    {
                        foreach (var obj in ResultQuery)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = obj.IdAseguradora;
                            aseguradora.Nombre = obj.Nombre;
                            aseguradora.FechaCreacion = obj.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = obj.FechaModificacion.ToString();

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = obj.Usuario.IdUsuario;

                            Result.Objects.Add(aseguradora);
                            Result.Correct = true;

                        }
                    }
                    else
                    {
                        Result.Correct = false;
                        Result.ErrorMessage = "No se encontraron registros en la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }

    }
}


