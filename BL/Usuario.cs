using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        {
                            cmd.Connection = context;
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure;


                            SqlParameter[] collection = new SqlParameter[10];

                            collection[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                            collection[0].Value = usuario.UserName;

                            collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                            collection[1].Value = usuario.Nombre;

                            collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                            collection[2].Value = usuario.ApellidoPaterno;

                            collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                            collection[3].Value = usuario.ApellidoPaterno;

                            collection[4] = new SqlParameter("@Email", SqlDbType.VarChar);
                            collection[4].Value = usuario.Email;

                            collection[5] = new SqlParameter("@Sexo", SqlDbType.Char);
                            collection[5].Value = usuario.Sexo;

                            collection[6] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                            collection[6].Value = usuario.Telefono;

                            collection[7] = new SqlParameter("@Celular", SqlDbType.VarChar);
                            collection[7].Value = usuario.Celular;

                            collection[8] = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar);
                            collection[8].Value = usuario.FechaNacimiento;

                            collection[9] = new SqlParameter("@Curp", SqlDbType.VarChar);
                            collection[9].Value = usuario.Curp;

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
                                result.ErrorMessage = "No se ha podido dar de alta al usuario";
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
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UsuarioEliminar", context))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter collection = new SqlParameter();

                        collection = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection.Value = usuario.IdUsuario;

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
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand("UsuarioUpdate", context))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[11];

                        collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[4].Value = usuario.Email;

                        collection[5] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        collection[6] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[7].Value = usuario.Celular;

                        collection[8] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[8].Value = usuario.FechaNacimiento;

                        collection[9] = new SqlParameter("Curp", SqlDbType.VarChar);
                        collection[9].Value = usuario.Curp;

                        collection[10] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[10].Value = usuario.IdUsuario;

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
        public static ML.Result GetAllSP()

        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand("UsuarioGetAll"))
                    {
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Sexo = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.FechaNacimiento = row[9].ToString();
                                usuario.Curp = row[10].ToString();
                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla de usuario";
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
        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = ("UsuarioGetByID");

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Sexo = row[6].ToString();
                            usuario.Telefono = row[7].ToString();
                            usuario.Celular = row[8].ToString();
                            usuario.FechaNacimiento = row[9].ToString();
                            usuario.Curp = row[10].ToString();

                            result.Object = usuario;
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No existen registros en la tabla Materia";
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                               usuario.Email, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.Curp, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia, usuario.Password, usuario.Status, usuario.Rol.IdRol);

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
                 
            }
            return result;
        }
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.UsuarioEliminar(usuario.IdUsuario);

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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                               usuario.Email, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.Curp, usuario.Imagen, usuario.Password, usuario.Status, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroExterior, usuario.Direccion.NumeroInterior, usuario.Direccion.Colonia.IdColonia);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la actualización";
                    }
                    //result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetbyIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var objUsuario = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.NombreUsuario;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        usuario.Curp = objUsuario.Curp;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Password = objUsuario.Password;
                        usuario.Status = objUsuario.Status.Value;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;
                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objUsuario.ColoniaNombre;
                        usuario.Direccion.Colonia.CodigoPostal = objUsuario.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.PaisNombre;
                      
                        result.Object = usuario;
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
                //using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                using (DLAzure1.LEscogidoAseguradoraEntities  context = new DLAzure1.LEscogidoAseguradoraEntities())
                {
                    var usuarios = context.UsuarioGetAll().ToList();
                    result.Objects = new List<object>();
                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Imagen = obj.Imagen;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.NombreUsuario;
                            usuario.NombreCompleto = obj.NombreCompleto;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.Curp = obj.Curp;
                            usuario.Password = obj.Password;
                            usuario.Status = obj.Status.Value;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = obj.IdDireccion;
                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = obj.IdColonia;
                            usuario.Direccion.Colonia.Nombre = obj.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;
                                                                                                       

                            result.Objects.Add(usuario);

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
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();
                    usuarioLinq.UserName = usuario.UserName;
                    usuarioLinq.Nombre = usuario.Nombre;
                    usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLinq.Email = usuario.Email;
                    usuarioLinq.Sexo = usuario.Sexo;
                    usuarioLinq.Telefono = usuario.Telefono;
                    usuarioLinq.Celular = usuario.Celular;
                    usuarioLinq.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", null);
                    usuarioLinq.Curp = usuario.Curp;

                    
                    Context.Usuarios.Add(usuarioLinq);             
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
        public static ML.Result GetAllLINQ()
        {
            ML.Result Result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var ResultQuery = from usuario in Context.Usuarios
                                      select usuario;

                    Result.Objects = new List<object>();
                    if (ResultQuery != null)
                    { 
                        foreach(var obj in ResultQuery)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Curp = obj.Curp;

                            Result.Objects.Add(usuario);
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
                catch(Exception ex)
                {
                    Result.Correct = false;
                    Result.ErrorMessage = ex.Message;
                    Result.Ex = ex;
                }
            return Result;
            }
        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var resultQuery = (from usuarioItem in context.Usuarios
                                       where usuarioItem.IdUsuario == usuario.IdUsuario
                                       select usuarioItem).FirstOrDefault();
                    if (resultQuery != null)
                    {
                        resultQuery.UserName = usuario.UserName;
                        resultQuery.Nombre = usuario.Nombre;
                        resultQuery.ApellidoPaterno = usuario.ApellidoPaterno;
                        resultQuery.ApellidoMaterno = usuario.ApellidoMaterno;
                        resultQuery.Email = usuario.Email;
                        resultQuery.Sexo = usuario.Sexo;
                        resultQuery.Telefono = usuario.Telefono;
                        resultQuery.Celular = usuario.Celular;
                        resultQuery.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", null);
                        resultQuery.Curp = usuario.Curp;

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
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex; 
            }
            return result; 
        }
        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result Result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities Context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var ResultQuery = (from usuario in Context.Usuarios
                                       where usuario.IdUsuario == IdUsuario
                                       select new { 
                                            usuario.IdUsuario,
                                            usuario.UserName,
                                            usuario.Nombre,
                                            usuario.ApellidoPaterno,
                                            usuario.ApellidoMaterno,
                                            usuario.Email,
                                            usuario.Sexo,
                                            usuario.Telefono,
                                            usuario.Celular,
                                            usuario.FechaNacimiento,
                                            usuario.Curp
                                       }).FirstOrDefault();

                    Result.Objects = new List<object>();

                    if (ResultQuery != null)
                    {
                            
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = ResultQuery.IdUsuario;
                            usuario.UserName = ResultQuery.UserName;
                            usuario.Nombre = ResultQuery.Nombre;
                            usuario.ApellidoPaterno = ResultQuery.ApellidoPaterno;
                            usuario.ApellidoMaterno = ResultQuery.ApellidoMaterno;
                            usuario.Email = ResultQuery.Email;
                            usuario.Sexo = ResultQuery.Sexo;
                            usuario.Telefono = ResultQuery.Telefono;
                            usuario.Celular = ResultQuery.Celular;
                            usuario.FechaNacimiento = ResultQuery.FechaNacimiento.ToString();
                            usuario.Curp = ResultQuery.Curp;

                            Result.Object = usuario;
                            Result.Correct = true;
                    }
                    else
                    {
                        Result.Correct = false;
                        Result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch(Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result Result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var resultQuery = (from usuarioItem in context.Usuarios
                                       where usuarioItem.IdUsuario == usuario.IdUsuario
                                       select usuarioItem).FirstOrDefault();
                    if (resultQuery != null)
                    {
                        context.Usuarios.Remove(resultQuery);
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
            catch(Exception ex)
            {
                Result.Correct = false;
                Result.ErrorMessage = ex.Message;
                Result.Ex = ex;
            }
            return Result;
        }
        public static ML.Result GetByUserName(string userName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.UsuarioGetByUserName(userName).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.Email = query.Email;

                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else 
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Credenciales Incorrectas";
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
        public static ML.Result UpdatePassword(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.UpdatePassword(usuario.Password, usuario.UserName);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        }
    }

 
