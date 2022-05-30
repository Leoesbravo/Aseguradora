using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;

namespace PL_MVC2.Controllers
{
    public class EmpleadoCargaMasivaController : Controller
    {

        [HttpGet] 
        public ActionResult CargaMasiva()
        {
            ML.ErrorExcel empleado = new ML.ErrorExcel();
            empleado.Empleado = new ML.Empleado();
            empleado.Empleado.empresa = new ML.Empresa();

 
            empleado.Errores = new List<object>();
            if (Session["RutaExcel"] != null)
            {
                empleado.Correct = true;
            }

            ML.Result result = BL.Empresa.GetAll();
            empleado.Empleado.empresa.Empresas = result.Objects;
            
            return View(empleado);
        }
        [HttpPost]
        public ActionResult CargaMasiva(ML.Empleado empleado)
        {
            if (Session["RutaExcel"] != null) //Que ya tiene la ruta del archivo
            {
                string direccionExcel = (string)Session["RutaExcel"];
                string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"].ToString();
                string ConnectionString = CadenaConexion + direccionExcel;


                ML.Result resultDataTable = BL.Empleado.ConvertXSLXtoDataTable(direccionExcel, ConnectionString);

                if (resultDataTable.Correct)
                {
                    string ErrorMessage = "";
                    DataTable tableEmpleado = (DataTable)resultDataTable.Object;//unboxing
                    foreach (DataRow row in tableEmpleado.Rows)
                    {
                        ML.Empleado empleadoTabla = new ML.Empleado(); //Empleado
                        ML.Result resultEmpleado = new ML.Result();

                        empleadoTabla.NumeroEmpleado = row[0].ToString();
                        empleadoTabla.Nombre = row[1].ToString();
                        empleadoTabla.ApellidoPaterno = row[2].ToString();
                        empleadoTabla.ApellidoMaterno = row[3].ToString();
                        empleadoTabla.RFC = row[4].ToString();
                        empleadoTabla.Email = row[5].ToString();
                        empleadoTabla.Telefono = row[6].ToString();

                        empleadoTabla.empresa = new ML.Empresa();
                        empleadoTabla.empresa.IdEmpresa = int.Parse(row[7].ToString());

                        resultEmpleado = BL.Empleado.Add(empleadoTabla);
                        if (!resultEmpleado.Correct)
                        {
                            ErrorMessage += resultEmpleado.ErrorMessage;
                        }
                    }

                    if (ErrorMessage == "")
                    {
                        ViewBag.Message = "Los empleados han sido cargados correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrió un error al insertar los empleados" + ErrorMessage;
                    }

                }

                //Cargar el archivo
            }
            else
            {
                //Validar el archivo
                HttpPostedFileBase file = Request.Files["ExcelEmpleado"];

                if (file.ContentLength > 0)//Si el usuario seleccionó un excel
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension == ".xlsx")
                    {
                        string direccionExcel = Server.MapPath("~/ExcelCargaMasivaEmpleado/") + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                        if (!System.IO.File.Exists(direccionExcel))
                        {
                            //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + direccionExcel + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";

                            try
                            {

                                file.SaveAs(direccionExcel);
                                Session["RutaExcel"] = direccionExcel;
                                string CadenaConexion = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"].ToString();
                                string ConnectionString = CadenaConexion + direccionExcel;

                                ML.Result resultDataTable = BL.Empleado.ConvertXSLXtoDataTable(direccionExcel, ConnectionString);

                                if (resultDataTable.Correct)
                                {
                                    //DataTable tableEmpleado = (DataTable)resultDataTable.Object;//unboxing
                                    ML.Result resultValidarExcel = BL.Empleado.ValidarExcel(resultDataTable.Objects);
                                    if (!resultValidarExcel.Correct) //si hubo errores
                                    {
                                        ML.ErrorExcel error = new ML.ErrorExcel();
                                        error.Errores = resultValidarExcel.Objects;
                                        error.Empleado = new ML.Empleado();
                                        error.Empleado.empresa = new ML.Empresa();
                                        ML.Result result = BL.Empresa.GetAll();
                                        error.Empleado.empresa.Empresas = result.Objects;
                                        return View(error);
                                    }
                                    else
                                    {
                                        ViewBag.Message = "Todos los registros han sido validados correctamente, puede proceder a cargarlos";
                                    }
                                }


                            }
                            catch (Exception ex)
                            {
                                ViewBag.Message = ex.Message;
                            }

                        }
                        else
                        {
                            ViewBag.Message = "Ya existe el nombre del archivo, por favor renombrarlo";
                        }

                    }
                    else
                    {
                        ViewBag.Message = "Seleccione un archivo con extensión .xlsx";
                    }
                }
                else
                {
                    ViewBag.Message = "Seleccione un archivo";
                }
            }
            return PartialView("Modal");
        }

    }
}