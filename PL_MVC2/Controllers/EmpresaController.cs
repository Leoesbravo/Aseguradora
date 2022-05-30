using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC2.Controllers
{
    public class EmpresaController : Controller
    {
        //
        // GET: /Empresa/
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empresa.GetAll();
            ML.Empresa empresa = new ML.Empresa();

            empresa.Empresas = result.Objects;

            return View(empresa);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (IdEmpresa == null) //Add
            {
                return View(empresa);
            }
            else //Update
            {
                ML.Result result = new ML.Result();
                result = BL.Empresa.GetByID(IdEmpresa.Value);


                if (result.Correct)
                {
                    empresa = ((ML.Empresa)result.Object);
                    return View(empresa);
                }
                else
                {

                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            if (file.ContentLength > 0)
            {
                empresa.Logo = ConvertToBytes(file);
            }

            if (ModelState.IsValid)
            {
                if (empresa.IdEmpresa == 0)
                {
                    result = BL.Empresa.Add(empresa);
                    if (result.Correct)
                    {
                        ViewBag.Message = "La empresa se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La empresa no se ha registrado correctamente " + result.ErrorMessage;
                    }

                }
                else
                {
                    result = BL.Empresa.Update(empresa);

                    if (result.Correct)
                    {
                        ViewBag.Message = "El registro se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "El registro no se ha actualizado correctamente " + result.ErrorMessage;
                    }


                }
            }
            else
            {
                return View(empresa);
            }
            return PartialView("Modal");
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Logo)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Logo.InputStream);
            data = reader.ReadBytes((int)Logo.ContentLength);

            return data;
        }
        public ActionResult Delete(int IdEmpresa)
        {


            ML.Empresa empresa = new ML.Empresa();
            empresa.IdEmpresa = IdEmpresa;
            ML.Result result = BL.Empresa.Delete(empresa);

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
	}
}