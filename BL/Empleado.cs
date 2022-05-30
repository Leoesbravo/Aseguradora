using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Data.OleDb;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                        var query = context.EmpleadoAdd(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.empresa.IdEmpresa);

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
        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.EmpleadoDelete(empleado.NumeroEmpleado);

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
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.empresa.IdEmpresa);

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
        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var empleados = context.EmpleadoGetAll(empleado.empresa.IdEmpresa, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno).ToList();

                    result.Objects = new List<object>();
                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            empleado = new ML.Empleado();
                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.RFC = obj.RFC;
                            empleado.Nombre = obj.NombreEmpleado;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.NSS = obj.NSS;
                            empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("dd/MM/yyyy");
                            empleado.Foto = obj.Foto;
                            empleado.empresa = new ML.Empresa();
                            empleado.empresa.IdEmpresa = obj.IdEmpresa;
                            empleado.empresa.Nombre = obj.Nombre;

                            result.Objects.Add(empleado);

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
        public static ML.Result GetById(string NumeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    var obj = context.EmpleadoGetById(NumeroEmpleado).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.NumeroEmpleado = obj.NumeroEmpleado;
                        empleado.RFC = obj.RFC;
                        empleado.Nombre = obj.Nombre;
                        empleado.ApellidoPaterno = obj.ApellidoPaterno;
                        empleado.ApellidoMaterno = obj.ApellidoMaterno;
                        empleado.Email = obj.Email;
                        empleado.Telefono = obj.Telefono;
                        empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        empleado.NSS = obj.NSS;
                        empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("dd/MM/yyyy");
                        empleado.Foto = obj.Foto;

                        empleado.empresa = new ML.Empresa();
                        empleado.empresa.IdEmpresa = obj.IdEmpresa.Value;

                        result.Object = empleado;
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
        public static ML.Result ConvertXSLXtoDataTable(string strFilePath, string connString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;


                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tableEmpleado = new DataTable();
                        da.Fill(tableEmpleado);

                        if (tableEmpleado.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableEmpleado.Rows) //
                            {
                                ML.Empleado empleado = new ML.Empleado();
                                empleado.NumeroEmpleado = row[0].ToString();
                                empleado.RFC = row[1].ToString();
                                empleado.Nombre = row[2].ToString();
                                empleado.ApellidoPaterno = row[3].ToString();
                                empleado.ApellidoMaterno = row[4].ToString();
                                empleado.Email = row[5].ToString();
                                empleado.Telefono = row[6].ToString();
                                empleado.FechaNacimiento = row[7].ToString();
                                empleado.NSS = row[8].ToString();
                                empleado.FechaIngreso = row[9].ToString();

                                result.Objects.Add(empleado);
                            }
                            result.Correct = true;
                        }
                        
                        result.Object = tableEmpleado;

                        if (tableEmpleado.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
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
        public static ML.Result ValidarExcel(List<object> Object)
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //DataTable  //Rows //Columns
                int i = 1;
                foreach (DataRow row in Object)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;

                    if (row[0].ToString() == "")
                    {
                        error.Mensaje += "Ingresar el número de empleado ";
                    }
                    if (row[1].ToString() == "")
                    {
                        error.Mensaje += "Ingresar el nombre del empleado ";
                    }
                    if (row[2].ToString() == "")
                    {
                        error.Mensaje += "Ingresar el Apellido Paterno del empleado ";
                    }
                    if (row[3].ToString() == "")
                    {
                        error.Mensaje += "Ingresar el Apellido Materno del empleado ";
                    }
                    if (row[4].ToString() == "")
                    {
                        error.Mensaje += "Ingresar el RFC del empleado ";
                    }

                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }


                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
        public static ML.Result AgregarExcel(DataTable tableEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoAseguradoraEntities context = new DL_EF.LEscogidoAseguradoraEntities())
                {
                    ML.Empleado empleado = new ML.Empleado();
                    empleado.empresa = new ML.Empresa();

                    foreach (DataRow row in tableEmpleado.Rows)
                    {
                        var query = context.EmpleadoAdd(empleado.NumeroEmpleado = row[0].ToString(), empleado.RFC = row[4].ToString(), empleado.Nombre = row[1].ToString(), empleado.ApellidoPaterno = row[2].ToString(), empleado.ApellidoMaterno = row[3].ToString(), empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.empresa.IdEmpresa);

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
