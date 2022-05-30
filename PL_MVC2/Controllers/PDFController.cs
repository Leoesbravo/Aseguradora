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
    public class PDFController : Controller
    {
        //
        // GET: /PDF/
        public ActionResult HacerPDF(string NumeroEmpleado)
        {
             ML.Empleado empleado = new ML.Empleado();
             ML.Result result  = new ML.Result();
             result = BL.Empleado.GetById(NumeroEmpleado);

             empleado = ((ML.Empleado)result.Object);
   

             Document documento = new Document(PageSize.LETTER);
             PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(Server.MapPath("~/PDFS/Doc" + empleado.Nombre + ".pdf"), FileMode.Create));
 
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
 
// Llenamos la tabla con información
clNombre = new PdfPCell(new Phrase(empleado.Nombre, _standardFont));
clNombre.BorderWidth = 0;
 
clApellido = new PdfPCell(new Phrase(empleado.ApellidoPaterno, _standardFont));
clApellido.BorderWidth = 0;
 
clPais = new PdfPCell(new Phrase(empleado.ApellidoMaterno, _standardFont));
clPais.BorderWidth = 0;
 
// Añadimos las celdas a la tabla
tblPrueba.AddCell(clNombre);
tblPrueba.AddCell(clApellido);
tblPrueba.AddCell(clPais);

documento.Add(tblPrueba);

documento.Close();
writer.Close();

            return View();
        }
	}
}