using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace PL_MVC2.Controllers
{
    public class AseguradoraController : Controller
    {
        //
        // GET: /Aseguradora/
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Aseguradora.GetAllEF();
            //ML.Aseguradora aseguradora = new ML.Aseguradora();

            //aseguradora.Aseguradoras = result.Objects;

            //return View(aseguradora);
            
       ML.Aseguradora resultaseguradora = new ML.Aseguradora();
       resultaseguradora.Aseguradoras = new List<Object>();
 
       using (var client = new HttpClient())
       {
           client.BaseAddress = new Uri("http://localhost:20048/api/");
 
           var responseTask = client.GetAsync("Aseguradora/GetAll ");
           responseTask.Wait();
 
           var result=responseTask.Result;
 
           if (result.IsSuccessStatusCode) 
           {
               var readTask = result.Content.ReadAsAsync<ML.Result>();
               readTask.Wait();
 
               foreach(var resultItem in readTask.Result.Objects)
               {
                   ML.Aseguradora resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(resultItem.ToString());
                   resultaseguradora.Aseguradoras.Add(resultItemList);
               }
           }
       }
       return View(resultaseguradora);
   }
        
        [HttpGet]
        public ActionResult Form(int? IdAseguradora)
        {
            ML.Aseguradora aseguradora = new ML.Aseguradora();

            ML.Result resultAsegurada = BL.Usuario.GetAllEF();
            aseguradora.Usuario = new ML.Usuario();
            aseguradora.Usuario.Usuarios = resultAsegurada.Objects;

            if (IdAseguradora == null) //Add
            {

                return View(aseguradora);
            }
            else //Update
            {
                ML.Result result = new ML.Result();
                using(var client = new HttpClient())
            try
            {
                    client.BaseAddress = new Uri("http://localhost:20048/api/");
                    var responseTask = client.GetAsync("Aseguradora/GetById/" + IdAseguradora);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Aseguradora resultItemList = new ML.Aseguradora();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Aseguradora>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;

                        aseguradora = ((ML.Aseguradora)result.Object);
                        aseguradora.Usuario.Usuarios = resultAsegurada.Objects;
                        return View(aseguradora);

                        //result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
                    }              
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return View();
        }
    }

            //    result = BL.Aseguradora.GetByIdEF(IdAseguradora.Value);


            //    if (result.Correct)
            //    {
            //        aseguradora = ((ML.Aseguradora)result.Object);
            //        aseguradora.Usuario.Usuarios = resultAsegurada.Objects;
            //        return View(aseguradora);
            //    }
            //    else
            //    {

            //    }
            //}
            //return View();
        //}
        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {
                if (aseguradora.IdAseguradora == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:20048/api/");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<ML.Aseguradora>("aseguradora/Add", aseguradora);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;
                        if (resultAseguradora.IsSuccessStatusCode)

                        {
                            ViewBag.Mensaje = "La aseguradora se registro correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La aseguradora no se ha registrado correctamente" + result.ErrorMessage;
                        }
                    }
                }
                else
                {

                    using (var client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("http://localhost:20048/api/");

                        //string BaseUpdate = "aseguradora/Update/" + aseguradora;

                        var postTask = client.PostAsJsonAsync<ML.Aseguradora>("Aseguradora/Update/" + aseguradora.IdAseguradora, aseguradora);
                        postTask.Wait();

                        var resultAseguradora = postTask.Result;

                        if (resultAseguradora.IsSuccessStatusCode)
                        {
                            ViewBag.Mensaje = "La aseguradora se ha actualizado correctamente";
                        }
                        else
                        {
                            ViewBag.Mensaje = "La aseguradora no se ha actualizado correctamente" + result.ErrorMessage;
                        }
                    }
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(int IdAseguradora)
        {


            //ML.Aseguradora aseguradora = new ML.Aseguradora();
            //aseguradora.IdAseguradora = IdAseguradora;
            //ML.Result result = BL.Aseguradora.DeleteEF(aseguradora);

            //if (result.Correct)
            //{
            //    ViewBag.message = "Se ha eliminado exitosamente el registro";
            //}
            //else
            //{
            //    ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            //}
            //return PartialView("Modal");

            ML.Result resultAseguradora = new ML.Result();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            aseguradora.IdAseguradora = IdAseguradora;
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:20048/api/");

                //HTTP POST
                var postTask = client.DeleteAsync("Aseguradora/Delete/" + IdAseguradora);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "La aseguradora ha sido eliminada";
                  
                }
                else
                {
                    ViewBag.Message = "La aseguradora no pudo ser eliminada" + resultAseguradora.ErrorMessage;
                }
            }

            return PartialView("Modal");
 

        }
	}
}