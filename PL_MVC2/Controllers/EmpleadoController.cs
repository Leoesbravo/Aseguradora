using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace PL_MVC2.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.empresa = new ML.Empresa();

            ML.Result result = BL.Empleado.GetAll(empleado);

            ML.Result resultEmpresa = BL.Empresa.GetAll();
            
            empleado.Empleados = result.Objects;
            empleado.empresa = new ML.Empresa();

            empleado.empresa.Empresas = resultEmpresa.Objects;

            return View(empleado);
        }
        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            empleado.ApellidoPaterno = (empleado.ApellidoPaterno == null) ? "" : empleado.ApellidoPaterno;
            empleado.ApellidoMaterno = (empleado.ApellidoMaterno == null) ? "" : empleado.ApellidoMaterno;
            ML.Result result = BL.Empleado.GetAll(empleado); //GetByIdSemestre(IdSemestre)

            empleado.Empleados = result.Objects;
            ML.Result resultEmpresa = BL.Empresa.GetAll();
            empleado.empresa.Empresas = resultEmpresa.Objects;
            return View(empleado);
        }
        [HttpGet]
        public ActionResult Form(string NumeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result resultEmpleado = BL.Empresa.GetAll();
            empleado.empresa = new ML.Empresa();
            empleado.empresa.Empresas = resultEmpleado.Objects;

            if (NumeroEmpleado == null) //Add
            {
                empleado.Action = "Add";
                return View(empleado);
            }
            else //Update
            {
                empleado.Action = "Update";

                ML.Result result = new ML.Result();
                result = BL.Empleado.GetById(NumeroEmpleado);


                if (result.Correct)
                {
                    empleado = ((ML.Empleado)result.Object);
                    empleado.empresa.Empresas = resultEmpleado.Objects;
                    return View(empleado);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                empleado.Foto = ConvertToBytes(file);
            }

            if (ModelState.IsValid)
            {
                if (empleado.Action == "Add")
                {
                    result = BL.Empleado.Add(empleado);
                    if (result.Correct)
                    {
                        ViewBag.Message = "El empleado se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "El empleado no se ha registrado correctamente " + result.ErrorMessage;
                    }

                }

                else
                {
                    result = BL.Empleado.Update(empleado);

                    if (result.Correct)
                    {
                        ViewBag.Message = "El empleado se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "El empleado no se ha actualizado correctamente " + result.ErrorMessage;
                    }

                }
            }
            else
            {
                empleado = new ML.Empleado();

                ML.Result resultEmpresa = BL.Empresa.GetAll();
                empleado.empresa = new ML.Empresa();
                empleado.empresa.Empresas = resultEmpresa.Objects;

                return View(empleado);
            }

                return PartialView("Modal");
            
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Foto)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            data = reader.ReadBytes((int)Foto.ContentLength);

            return data;
        }
        public ActionResult Delete(string NumeroEmpleado)
        {


            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = NumeroEmpleado;
            ML.Result result = BL.Empleado.Delete(empleado);

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado exitosamente el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("Modal");
        }
        public ActionResult HacerPDF(int IdEmpresa)
        {
            ML.Empleado empleado = new ML.Empleado();

            string Nombre = empleado.Nombre = "";
            string ApellidoPaterno = empleado.ApellidoPaterno = "";
            string ApellidoMaterno = empleado.ApellidoMaterno = "";

            empleado.empresa = new ML.Empresa();
            empleado.empresa.IdEmpresa = IdEmpresa;
            ML.Result resultempleado = BL.Empleado.GetAll(empleado);
            empleado.Empleados = resultempleado.Objects;

            Document documento = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(Server.MapPath("~/PDFS/Doc" + IdEmpresa + ".pdf"), FileMode.Create));

            documento.AddTitle("Mi primer PDF");
            documento.AddCreator("Leonardo Bravo");

            documento.Open();

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            documento.Add(new Paragraph("Empleados"));
            documento.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre Empleado", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido Materno", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("Apellido Paterno", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            foreach (ML.Empleado empleadoitem in resultempleado.Objects.ToList())
            {
                tblPrueba.AddCell(empleadoitem.Nombre);
                tblPrueba.AddCell(empleadoitem.ApellidoPaterno);
                tblPrueba.AddCell(empleadoitem.ApellidoMaterno);
            }

            documento.Add(tblPrueba);

            documento.Close();
            writer.Close();

            //ViewBag.Message = "Se ha generado el reporte en la carpeta correspondiete";

            

            //return View("Modal");
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/PDFS/Doc" + IdEmpresa + ".pdf"));
            MemoryStream ms = new MemoryStream(fileBytes, 0, 0, true, true);
            Response.AddHeader("content-disposition", "attachment;filename= Doc" + empleado.Nombre + ".pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();
            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
	}
}