using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC2.Controllers
{
    public class PolizaController : Controller
    {
        //
        // GET: /Poliza/
  
        public ActionResult GetAll()
        {
            ML.Result result = BL.Poliza.GetAll();
            ML.Poliza poliza = new ML.Poliza();

            poliza.Polizas = result.Objects;

            return View(poliza);
        }
        [HttpGet]
        public ActionResult Form(int? IdPoliza)
        {
            ML.Poliza poliza = new ML.Poliza();
            poliza.Vigencia = new ML.Vigencia();

            ML.Result resultUsuario = BL.Usuario.GetAllEF();
            poliza.Usuario = new ML.Usuario();

            ML.Result resultSubPoliza = BL.SubPoliza.GetAllEF();
            poliza.SubPoliza = new ML.SubPoliza();

            poliza.SubPoliza.Subpolizas = resultSubPoliza.Objects;
            poliza.Usuario.Usuarios = resultUsuario.Objects;

            if (IdPoliza == null) //Add
            {
                return View(poliza);
            }
            else //Update
            {
                ML.Result result = new ML.Result();
                result = BL.Poliza.GetbyId(IdPoliza.Value);
                if (result.Correct)
                {
                   
                    
                    poliza.Usuario = new ML.Usuario();
                    poliza.SubPoliza = new ML.SubPoliza();
                    poliza.SubPoliza.Subpolizas = resultSubPoliza.Objects;
                    poliza.Usuario.Usuarios = resultUsuario.Objects;

                    poliza = ((ML.Poliza)result.Object);

                    ML.Result resultUs = BL.Usuario.GetAllEF();
                    ML.Result resultSP = BL.SubPoliza.GetAllEF();

                    poliza.SubPoliza.Subpolizas = resultSubPoliza.Objects;
                    poliza.Usuario.Usuarios = resultUsuario.Objects;

                   
                    return View(poliza);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Poliza poliza)
        {
            ML.Result result = new ML.Result();

            if (poliza.IdPoliza == 0)
            {
                result = BL.Poliza.Add(poliza);
                if (result.Correct)
                {
                    ViewBag.Message = "El usuario se ha registrado correctamente";
                }
                else
                {
                    ViewBag.Message = "El usuario no se ha registrado correctamente " + result.ErrorMessage;
                }

            }
            else
            {
                result = BL.Poliza.Update(poliza);

                if (result.Correct)
                {
                    ViewBag.Message = "El registro se ha actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "El registro no se ha actualizado correctamente " + result.ErrorMessage;
                }


            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdPoliza)
        {


            ML.Poliza poliza = new ML.Poliza();
            poliza.IdPoliza = IdPoliza;
            ML.Result result = BL.Poliza.Delete(poliza);

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