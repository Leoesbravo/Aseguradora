using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC2.Controllers
{
    public class SubPolizaController : Controller
    {
        //
        // GET: /SubPoliza/
        public ActionResult GetAll()
        {
            ML.Result result = BL.SubPoliza.GetAllEF();
            ML.SubPoliza subpoliza = new ML.SubPoliza();

            subpoliza.Subpolizas = result.Objects;

            return View(subpoliza);
        }
        [HttpGet]
        public ActionResult Form(int? IdSubPoliza)
        {
            ML.SubPoliza subpoliza = new ML.SubPoliza();

            ML.Result resultSubPoliza = BL.SubPoliza.GetAllEF();

            if (IdSubPoliza == null) //Add
            {
                return View(subpoliza);
            }
            else //Update
            {
                ML.Result result = new ML.Result();
                result = BL.SubPoliza.GetById(IdSubPoliza.Value);


                if (result.Correct)
                {
                    subpoliza = ((ML.SubPoliza)result.Object);
                    return View(subpoliza);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.SubPoliza subPoliza)
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {
                if (subPoliza.IdSubPoliza == 0)
                {
                    result = BL.SubPoliza.Add(subPoliza);
                    if (result.Correct)
                    {
                        ViewBag.Message = "La Sub Poliza se ha registrado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La Sub Poliza no se ha registrado correctamente " + result.ErrorMessage;
                    }

                }
                else
                {
                    result = BL.SubPoliza.Update(subPoliza);

                    if (result.Correct)
                    {
                        ViewBag.Message = "La Sub Poliza se ha actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "La Sub Poliza no se ha actualizado correctamente " + result.ErrorMessage;
                    }


                }
            }
            else
            {
                return View(subPoliza);
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdSubPoliza)
        {


            ML.SubPoliza subpoliza = new ML.SubPoliza();
            subpoliza.IdSubPoliza = IdSubPoliza;
            ML.Result result = BL.SubPoliza.Delete(subpoliza);

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